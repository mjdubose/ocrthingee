﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IOCRTHINGEE;

//https://github.com/mjdubose/ocrthingee.git
namespace OCRTHINGEE
{
    public partial class OCRThingee : Form
    {
        readonly PrivateFontCollection _pfc = new PrivateFontCollection();
        public static string Stationname;
        public static string Systemname;
        private List<RowAsText> _currentTextValues = new List<RowAsText>();
        private string _path;
        private List<Row> _rowholder = new List<Row>();
        private readonly AutoCompleteStringCollection _source = new AutoCompleteStringCollection();
        private readonly List<string> _stationcollectionstrings = new List<string>();
        private readonly AutoCompleteStringCollection _stationsource = new AutoCompleteStringCollection();
        private readonly List<string> _systemcollectionstrings = new List<string>();
        ShowSystemName _showSystemName;
        private static readonly IOCRENGINE InterfaceOcr = new Tesseract();


        public OCRThingee()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            _path = openFileDialog1.FileName;
            label9.Text = openFileDialog1.FileName;

            pb1.Image = Image.FromFile(_path);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_path == null)
            {
                MessageBox.Show(@"Please load an image!");
                return;
            }

            pb1.Image = Image.FromFile(_path);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog
            {
                Filter = @"Image Files (*.bmp)|*.bmp",
                FilterIndex = 4,
                RestoreDirectory = true
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                pb1.Image.Save(save.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_path != null)
            { 
                pb1.Image = pb1.Image.FilterImage(r1.Value, r2.Value, g1.Value, g2.Value, b1.Value, b2.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_path != null)
            {
                pb1.Image = pb1.Image.Invert();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (_path != null)
            {
                pb1.Image = pb1.Image.Crop();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (_path == null) return;
            _rowholder.Clear();
            pb1.Image = pb1.Image.DefineRowsForImageRipping(_rowholder);
        }

    
        private async void button17_Click(object sender, EventArgs e)
        {
            _currentTextValues.Clear();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;

            btn_AddRowToDatabase.Enabled = false;
            try
            {
                if (!GetSystemName()) return;
                var temp = (pb1.Image as Bitmap).Clone(0, 0, pb1.Image.Width, pb1.Image.Height);
                var task = PrepareForOcrAsync(temp, r1.Value, r2.Value, g1.Value, g2.Value, b1.Value, b2.Value);
                var picture = await task;
                _rowholder.Clear();
                var task2 = DefineRowsForImageRippingAsync(picture, _rowholder);
                var imageandrowlistresults = await task2;
                _rowholder = imageandrowlistresults.listrow;
                var task3 = RipEliteColumnAndRowsAndOcrAsync(imageandrowlistresults.image,
                    imageandrowlistresults.listrow);
                _currentTextValues = await task3;
                pb1.Image = pb1.Image.Crop().FilterImage(r1.Value, r2.Value, g1.Value, g2.Value, b1.Value, b2.Value).Invert();
                PopulateDataGridView();
                dg_OCRRows.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button14.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                btn_AddRowToDatabase.Enabled = true;
            }
        }

        private static Task<Image> PrepareForOcrAsync(Image imageToBeCleaned, decimal r1, decimal r2, decimal g1,
            decimal g2,
            decimal b1, decimal b2)
        {
            return Task.Run(() => (Image)imageToBeCleaned.FilterImage(r1, r2, g1, g2, b1, b2).Invert().Crop());
        }

        private static Task<ImageAndRowList> DefineRowsForImageRippingAsync(ICloneable pbimage, List<Row> rowlist)
        {
            return pbimage == null ? null : Task.Run(() => DefineRowsAsync(pbimage, rowlist));
        }

        private static Task<Bitmap> ClearHorizontalBarsAsync(Bitmap image)
        {
            return Task.Run(() => Extensions.ClearHorizontalBars(image));
        }

        private static async Task<ImageAndRowList> DefineRowsAsync(ICloneable pbimage, List<Row> rowlist)
        {
            var clone = (Image)pbimage.Clone();
            var task = ClearHorizontalBarsAsync((Bitmap)clone);

            return DefineRows(rowlist, new Bitmap(await task));
        }

        private static ImageAndRowList DefineRows(List<Row> rowlist, Image imageX)
        {
            var vert = 0;

            var image = new LockBitmap((Bitmap)imageX.Clone());
            image.LockBits();
            while (vert < image.Height)
            {
                var hor = 0;
                while (hor < image.Width)
                {
                    var color = image.GetPixel(hor, vert);


                    if (color.R == 255 && color.G == 255 && color.B == 255)
                    {
                        image.SetPixel(hor, vert, Color.Green);

                        hor++;
                    }
                    else
                    {
                        hor = image.Width;
                    }
                }
                vert++;
            }

            for (var x = 0; x < image.Height; x++)
            {
                var color = image.GetPixel(image.Width - 1, x);

                if (color.R != 255 && color.G != 255 && color.B != 255)
                {
                    x++;
                }
                else
                {
                    var i = x - 2;
                    if (i < 0)
                    {
                        i = 0;
                    }
                    var thisrow = new Row { RowTop = i };
                    while (color.R == 255 && color.G == 255 && color.B == 255 && x < image.Height - 1)
                    {
                        x++;
                        color = image.GetPixel(image.Width - 1, x);
                    }

                    thisrow.RowBottom = x + 2;

                    if (thisrow.RowBottom - thisrow.RowTop > ((int)(image.Height * .0088)))
                    {
                        rowlist.Add(thisrow);
                    }
                }
            }
            image.UnlockBits();

            return new ImageAndRowList { image = imageX, listrow = rowlist };
        }

        private bool GetSystemName()
        {
            if (pb1.Image == null) return false;
            var source = new Bitmap(pb1.Image);

            var systemName = source.Clone(54 * source.Height / 900, 61 * source.Width / 1600, 340 * source.Width / 1600,
                78 * source.Height / 900 - 54 * source.Height / 900).ResizeBmp();

            if (!Directory.Exists(@"c:\ocrtest"))
            {
                try
                {
                    Directory.CreateDirectory(@"c:\ocrtest");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }

            }

            systemName.Save(@"c:\ocrtest\SystemName.Tiff", ImageFormat.Tiff);
            Stationname = InterfaceOcr.GetText(@"c:\ocrtest\SystemName.Tiff");
            if (Stationname == null) return false;
            pb2.Image = systemName;


            var t = Top;
            var l = Left;
            _showSystemName.DesktopLocation = new Point(l + 100, t + 100);

            return _showSystemName.ShowDialog() == DialogResult.OK;
        }

        private void PopulateDataGridView()
        {
            dg_OCRRows.DataSource = null;
            dg_OCRRows.Rows.Clear();
            dg_OCRRows.Refresh();

            AddDataGridViewColumns();

            var productlist = new ConsumerItemsList();

            RemoveRowsWithNoValidEntries(productlist);
        }

        private void RemoveRowsWithNoValidEntries(ConsumerItemsList productlist)
        {
            foreach (var x in _currentTextValues.Where(x => (x.SellPrice != "") || (x.BuyPrice != "") || (x.NumSupply != "")  || (x.GalacticAverage != "")))
            {
                GridviewDisplayedDataCleanUp(x, productlist);
                dg_OCRRows.Rows.Add(MakeNewDataGridViewRow(x));
            }
        }

        private static void GridviewDisplayedDataCleanUp(RowAsText x, ConsumerItemsList productlist)
        {
            x.GoodsName = productlist.ReturnMostSimilarWord(x.GoodsName);
           
            if (x.SellPrice == "")
            {
                x.SellPrice = "0";
            }
            if (x.BuyPrice == "")
            {
                x.BuyPrice = "0";
            }
      
            if (x.NumSupply == "")
            {
                x.NumSupply = "0";
            }
            if (x.GalacticAverage == "")
            {
                x.GalacticAverage = "0";
            }
        }

        private DataGridViewRow MakeNewDataGridViewRow(RowAsText x)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dg_OCRRows, Systemname, Stationname, x.GoodsName, x.SellPrice, x.BuyPrice, x.NumSupply,
                 x.GalacticAverage);
            row.DefaultCellStyle.BackColor = Color.Black;
            row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 128, 0);
            row.DefaultCellStyle.Font = new Font("Eurostile", 10, FontStyle.Regular);
            row.DefaultCellStyle.SelectionBackColor = Color.Red;
            return row;
        }

        private void AddDataGridViewColumns()
        {
            if (dg_OCRRows.Columns.Count != 0) return;

            dg_OCRRows.Columns.Add(new DataGridViewTextBoxColumn());
            dg_OCRRows.Columns.Add(new DataGridViewTextBoxColumn());
            dg_OCRRows.Columns.Add(new DataGridViewTextBoxColumn());
            dg_OCRRows.Columns.Add(new DataGridViewTextBoxColumn());
            dg_OCRRows.Columns.Add(new DataGridViewTextBoxColumn());
            dg_OCRRows.Columns.Add(new DataGridViewTextBoxColumn());
            dg_OCRRows.Columns.Add(new DataGridViewTextBoxColumn());
            dg_OCRRows.Columns[0].Name = "SystemName";
            dg_OCRRows.Columns[1].Name = "StationName";
            dg_OCRRows.Columns[2].Name = "GoodsName";
            dg_OCRRows.Columns[3].Name = "SellPrice";
            dg_OCRRows.Columns[4].Name = "BuyPrice";
            dg_OCRRows.Columns[5].Name = "NumSupply";
            dg_OCRRows.Columns[6].Name = "GalacticAverage";
        }

        public Task UpdateDatabaseAsync(elite_testingEntities elite, DataGridView thegrid)
        {
            return Task.Run(() => UpdateDatabase(elite, thegrid));
        }

        public Task<List<RowAsText>> RipEliteColumnAndRowsAndOcrAsync(Image image, IEnumerable<Row> rowHolder)
        {
            return Task.Run(() => Ocr(image, rowHolder));
        }

        private static List<RowAsText> Ocr(Image image, IEnumerable<Row> rowHolder)
        {
            var source = new Bitmap(image);
            var currentTextValues = new List<RowAsText>();
            var rowbmpholder = rowHolder.Select(rownum => new RowBmpHolder
            {
                GoodsName =
                    source.Clone(rownum.RowTop, 0, 303 * source.Width / 1000, rownum.RowBottom - rownum.RowTop).ResizeBmp(),
                SellPrice =
                    source.Clone(rownum.RowTop, 308 * source.Width / 1000, 80 * source.Width / 1000,
                        rownum.RowBottom - rownum.RowTop)
                        .ResizeBmp(),
                BuyPrice =
                    source.Clone(rownum.RowTop, 381 * source.Width / 1000, 71 * source.Width / 1000,
                        rownum.RowBottom - rownum.RowTop)
                        .ResizeBmp(),
             
                NumSupply =
                    source.Clone(rownum.RowTop, 684 * source.Width / 1000, 90 * source.Width / 1000,
                        rownum.RowBottom - rownum.RowTop)
                        .ResizeBmp(),
               
                GalacticAverage =
                    source.Clone(rownum.RowTop, 851 * source.Width / 1000, 152 * source.Width / 1000,
                        rownum.RowBottom - rownum.RowTop)
                        .ResizeBmp()
            }).ToList();

            foreach (var temp in rowbmpholder)
            {
                var tesseract = new RowAsText();

                temp.GoodsName.Save(@"c:\ocrtest\GoodsName.Tiff", ImageFormat.Tiff);
                tesseract.GoodsName = InterfaceOcr.GetText(@"c:\ocrtest\GoodsName.Tiff");
                @"c:\ocrtest\GoodsName.Tiff".TryToDelete();

                temp.SellPrice.Save(@"c:\ocrtest\SellPrice.Tiff", ImageFormat.Tiff);
                tesseract.SellPrice = InterfaceOcr.GetText(@"c:\ocrtest\SellPrice.Tiff");
                @"c:\ocrtest\SellPrice.Tiff".TryToDelete();

                temp.BuyPrice.Save(@"c:\ocrtest\BuyPrice.Tiff", ImageFormat.Tiff);
                tesseract.BuyPrice = InterfaceOcr.GetText(@"c:\ocrtest\BuyPrice.Tiff");
                @"c:\ocrtest\BuyPrice.Tiff".TryToDelete();

                temp.NumSupply.Save(@"c:\ocrtest\NumSupply.Tiff", ImageFormat.Tiff);
                tesseract.NumSupply = InterfaceOcr.GetText(@"c:\ocrtest\NumSupply.Tiff");
                @"c:\ocrtest\NumSupply.Tiff".TryToDelete();

               temp.GalacticAverage.Save(@"c:\ocrtest\x.Tiff", ImageFormat.Tiff);
                tesseract.GalacticAverage = InterfaceOcr.GetText(@"c:\ocrtest\x.Tiff");
                @"c:\ocrtest\x.Tiff".TryToDelete();

                currentTextValues.Add(tesseract);
            }


            return currentTextValues;
        }

  
        private void btn_DeleteRow_Click(object sender, EventArgs e)
        {
            foreach (var oneCell in dg_OCRRows.SelectedCells.Cast<DataGridViewCell>().Where(oneCell => oneCell.Selected)
                )
            {
                dg_OCRRows.Rows.RemoveAt(oneCell.RowIndex);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            do
            {
                for (int index = 0; index < dg_OCRRows.Rows.Count; index++)
                {
                    DataGridViewRow row = dg_OCRRows.Rows[index];
                    dg_OCRRows.Rows.Remove(row);
                }
            } while (dg_OCRRows.Rows.Count > 1);
            dg_OCRRows.Rows.Clear();

            dg_OCRRows.Refresh();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
          

            LoadFont();


            tradeitemsTableAdapter.Fill(eliteDataSet.tradeitems);

            stationsTableAdapter.Fill(eliteDataSet.stations);

            systemsTableAdapter.Fill(eliteDataSet.systems);

            itemsTableAdapter.Fill(eliteDataSet.items);

            _showSystemName = new ShowSystemName();

        }

        private unsafe void LoadFont()
        {
            const string fontName = "Eurostile";
            const float fontSize = 12;

            using (var fontTester = new Font(
                fontName,
                fontSize,
                FontStyle.Regular,
                GraphicsUnit.Pixel))
            {
                if (fontTester.Name == fontName) return;
                Stream fontStream = GetType().Assembly.GetManifestResourceStream("OCRTHINGEE.Eurostile.ttf");

                   
                if (fontStream != null)
                {
                    var fontdata = new byte[fontStream.Length];

                    fontStream.Read(fontdata, 0, (int) fontStream.Length);

                    fontStream.Close();

                    fixed (byte* pFontData = fontdata)
                    {
                        _pfc.AddMemoryFont((IntPtr) pFontData, fontdata.Length);
                    }
                    foreach (var ff in _pfc.Families)
                    {
                        var fn = new Font(ff, 18, FontStyle.Bold);
                        foreach (var c in Controls.OfType<DataGridView>())
                        {
                            c.Font = fn;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Issue loading font");
                }
            }
        }

        private async void btn_AddRowToDatabase_Click(object sender, EventArgs e)
        {
            using (var elite = new elite_testingEntities())
            {
                try
                {
                    var cloned = new DataGridView();
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns.Add(new DataGridViewTextBoxColumn());
                    cloned.Columns[0].Name = "SystemName";
                    cloned.Columns[1].Name = "StationName";
                    cloned.Columns[2].Name = "GoodsName";
                    cloned.Columns[3].Name = "SellPrice";
                    cloned.Columns[4].Name = "BuyPrice";
                    cloned.Columns[5].Name = "NumSupply";
                    cloned.Columns[6].Name = "GalacticAverage";

                    foreach (var y in
                        dg_OCRRows.Rows.Cast<DataGridViewRow>().Where(y => y.Cells[2].Value.ToString() != ""))
                    {
                        cloned.Rows.Add(CloneWithValues(y));
                    }
                    var task = UpdateDatabaseAsync(elite, cloned);
                    await task;
                    tradeitemsTableAdapter.Fill(eliteDataSet.tradeitems);

                    stationsTableAdapter.Fill(eliteDataSet.stations);

                    systemsTableAdapter.Fill(eliteDataSet.systems);

                    itemsTableAdapter.Fill(eliteDataSet.items);

                    dataGridView2.Refresh();
                    dataGridView3.Refresh();
                    dataGridView4.Refresh();
                    dataGridView5.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            var clonedRow = (DataGridViewRow)row.Clone();
            for (var index = 0; index < row.Cells.Count; index++)
            {
                if (clonedRow != null) clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }

        private static void UpdateDatabase(elite_testingEntities elite, DataGridView thegrid)
        {
            var thissystem = elite.Systems.ToList();

            for (int index = 0; index < thegrid.Rows.Count; index++)
            {
                DataGridViewRow y = thegrid.Rows[index];
                if (y.Cells[0].FormattedValue == null) continue;
                if (string.IsNullOrEmpty(y.Cells[0].FormattedValue.ToString())) continue;
                if (y.Cells[1].FormattedValue == null) continue;
                if (string.IsNullOrEmpty(y.Cells[1].FormattedValue.ToString())) continue;
                if (y.Cells[2].FormattedValue == null) continue;
                if (string.IsNullOrEmpty(y.Cells[2].FormattedValue.ToString())) continue;
                if (y.Cells[3].FormattedValue == null) continue;
                if (string.IsNullOrEmpty(y.Cells[3].FormattedValue.ToString())) continue;
                if (y.Cells[4].FormattedValue == null) continue;
                if (string.IsNullOrEmpty(y.Cells[4].FormattedValue.ToString())) continue;
                if (y.Cells[5].FormattedValue == null) continue;
                if (string.IsNullOrEmpty(y.Cells[5].FormattedValue.ToString())) continue;
                if (y.Cells[6].FormattedValue == null) continue;
                if (string.IsNullOrEmpty(y.Cells[6].FormattedValue.ToString())) continue;


                var system = y.Cells[0].FormattedValue.ToString();
                var station = y.Cells[1].FormattedValue.ToString();
                station = station.RemoveChars('\n');
                var goodsname = y.Cells[2].FormattedValue.ToString();
                var sellprice = y.Cells[3].FormattedValue.ToString();
                var buyprice = y.Cells[4].FormattedValue.ToString();
                var numsupply = y.Cells[5].FormattedValue.ToString();

                var thesystem = thissystem.Find(s => s.name == system);

                if (thesystem == null)
                {
                    elite.Systems.Add(new system { name = system });
                    elite.SaveChanges();
                    thissystem = elite.Systems.ToList();

                    thesystem = thissystem.Find(s => s.name == system);
                }

                var count = elite.Stations.Count(s => s.sysid == thesystem.sysId);
                station thestation;
                List<station> systemstationlist;
                if (count < 1)
                {
                    thestation = null;
                }
                else
                {
                    systemstationlist = elite.Stations.Where(s => s.sysid == thesystem.sysId).ToList();
                    thestation = systemstationlist.Find(s => s.name == station);
                }


                if (thestation == null)
                {
                    elite.Stations.Add(new station { name = station, sysid = thesystem.sysId });

                    elite.SaveChanges();

                    systemstationlist = elite.Stations.Where(s => s.sysid == thesystem.sysId).ToList();
                    thestation = systemstationlist.Find(s => s.name == station);
                }

                var goodslist = elite.Items.ToList();
                var thisgood = goodslist.Find(s => s.name == goodsname);
                if (thisgood == null)
                {
                    elite.Items.Add(new item { name = goodsname });
                    elite.SaveChanges();
                    goodslist = elite.Items.ToList();
                    thisgood = goodslist.Find(s => s.name == goodsname);
                }


                var tradeitemlist =
                    elite.Tradeitems.Where(s => s.stationid == thestation.stationId).ToList();
                var thistradeitem = tradeitemlist.Find(s => s.itemid == thisgood.itemId);
                if (buyprice == "")
                {
                    buyprice = "0";
                }

                if (sellprice == "")
                {
                    sellprice = "0";
                }
                if (numsupply == "")
                {
                    numsupply = "0";
                }
                var decbuyprice = int.Parse(buyprice);
                var decsellprice = int.Parse(sellprice);
                var intsupply = int.Parse(numsupply);
                if (thistradeitem != null)
                {
                    thistradeitem.lastupdate = DateTime.Now;
                    thistradeitem.buyprice = decbuyprice;
                    thistradeitem.sellprice = decsellprice;
                    thistradeitem.supply = intsupply;

                    elite.SaveChanges();
                }
                else
                {
                    elite.Tradeitems.Add(new tradeitem
                    {
                        lastupdate = DateTime.Now,
                        stationid = thestation.stationId,
                        itemid = thisgood.itemId,
                        buyprice = decbuyprice,
                        sellprice = decsellprice,
                        supply = intsupply
                    });
                    elite.SaveChanges();
                }
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab != tabControl2.TabPages["TabPage1"]) return;
            _source.Clear();
            _systemcollectionstrings.Clear();

            var systemvalues = new Dictionary<int, string>();
            using (var elite = new elite_testingEntities())
            {
                var systemcollection = from p in elite.Systems select p;
                _systemcollectionstrings.AddRange(systemcollection.Select(x => x.name));
                foreach (var v in systemcollection.ToList())
                {
                    systemvalues.Add(v.sysId, v.name);
                }
            }
            _source.AddRange(_systemcollectionstrings.ToArray());
            comboBox1.DataSource = new BindingSource(systemvalues, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteCustomSource = _source;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            comboBox4.DataSource = new BindingSource(systemvalues, null);
            comboBox4.DisplayMember = "Value";
            comboBox4.ValueMember = "Key";
            comboBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox4.AutoCompleteCustomSource = _source;
            comboBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = (ComboBox)sender;
            if (cmb.SelectedItem == null) return;
            var x = (KeyValuePair<int, string>)cmb.SelectedItem;
            _stationcollectionstrings.Clear();
            var stationvalues = new Dictionary<int, string>();

            using (var elite = new elite_testingEntities())
            {
                var stationcollection = from p in elite.Systems
                                        where p.sysId == x.Key
                                        join u in elite.Stations on p.sysId equals u.sysid
                                        select u;
                var list = stationcollection.ToList();
                if (list.Count > 0)
                {
                    _stationcollectionstrings.AddRange(stationcollection.Select(station => station.name));

                    _stationsource.AddRange(_stationcollectionstrings.ToArray());


                    foreach (var station in list)
                    {
                        stationvalues.Add(station.stationId, station.name);
                    }
                }
                else
                {
                    _stationsource.Add("");
                    stationvalues.Add(0, "NO STATION");
                }
            }
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
            comboBox2.DataSource = new BindingSource(stationvalues, null);
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteCustomSource = _stationsource;
            comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text == "")
            {
                MessageBox.Show(@"Enter the number of cargo spaces in the ship.");
                return;
            }

            if (CreditsTextBox.Text == "")
            {
                MessageBox.Show(@"Enter the amount of credits you have.");
            }


            int num;
            if (!int.TryParse(txtCargo.Text, out num)) return;

            int credits;
            if (!int.TryParse(CreditsTextBox.Text, out credits)) return;

            using (var elite = new elite_testingEntities())
            {
                var originatingstationKvp = (KeyValuePair<int, string>)comboBox2.SelectedItem;

                if (originatingstationKvp.Key == 0)
                    return;
                var destinationsystemKey = (KeyValuePair<int, string>)comboBox4.SelectedItem;

                var destinationstation = from system in elite.Systems
                                         join station in elite.Stations on system.sysId equals station.sysid
                                         join tradeitem in elite.Tradeitems on station.stationId equals tradeitem.stationid
                                         join item in elite.Items on tradeitem.itemid equals item.itemId
                                         where tradeitem.sellprice > 0
                                         where system.sysId == destinationsystemKey.Key
                                         select new 
                                         {
                                             TradeitemId = tradeitem.itemid,
                                             SystemName = system.name,
                                              StationID = station.stationId,
                                             StationName = station.name,
                                             TradeItemName = item.name,
                                             Supply = tradeitem.supply,
                                             BuyPrice = tradeitem.buyprice,
                                             SellPrice = tradeitem.sellprice
                                         };
             


                var originatingstation = from station in elite.Stations
                                         join tradeitem in elite.Tradeitems on station.stationId equals tradeitem.stationid
                                         join item in elite.Items on tradeitem.itemid equals item.itemId
                                         join system in elite.Systems on station.sysid equals system.sysId
                                         where tradeitem.supply > 0
                                         where tradeitem.buyprice > 0
                                         where station.stationId == originatingstationKvp.Key
                                         select new 
                                         {
                                             TradeitemId = tradeitem.itemid,
                                             SystemName = system.name,
                                             StationID = station.stationId,
                                             StationName = station.name,
                                             TradeItemName = item.name,
                                             Supply = tradeitem.supply,
                                             BuyPrice = tradeitem.buyprice,
                                             SellPrice = tradeitem.sellprice
                                         };

               
              

                var profit = from t in originatingstation
                             join f in destinationstation
                                 on t.TradeitemId equals f.TradeitemId
                             where t.BuyPrice < f.SellPrice && (credits / t.BuyPrice > 0)
                             let numberBought = (credits / t.BuyPrice) > num ? num : (credits / t.BuyPrice)
                             select new
                             {
                                 TradeitemID = f.TradeitemId,
                                 f.SystemName,
                                 f.StationID,
                                 f.StationName,
                                 f.TradeItemName,
                                 t.Supply,
                                 t.BuyPrice,
                                 f.SellPrice,
                                 NumberBought = numberBought,
                                 Profit = (f.SellPrice - t.BuyPrice) * numberBought
                             };


                var y = profit.ToList();
                 
              
                y = y.OrderByDescending(v => v.Profit).GroupBy(v => v.StationID).SelectMany(g => g).ToList();

                var bindingSource1 = new BindingSource { DataSource = y };

                dataGridView1.DataSource = bindingSource1;

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedCells.Count <= 0) return;
            var selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

            var selectedRow = dataGridView2.Rows[selectedrowindex];

            var a = Convert.ToInt32(selectedRow.Cells[0].Value);

            stationsTableAdapter.FillByID(eliteDataSet.stations, a);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            systemsTableAdapter.Update(eliteDataSet.systems);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count <= 0) return;
            var selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

            var selectedRow = dataGridView2.Rows[selectedrowindex];

            var a = Convert.ToInt32(selectedRow.Cells[0].Value);
            systemsTableAdapter.Delete(a);
            systemsTableAdapter.Fill(eliteDataSet.systems);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count <= 0) return;
            var selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;

            var selectedRow = dataGridView3.Rows[selectedrowindex];

            var a = Convert.ToInt32(selectedRow.Cells[0].Value);
            var b = Convert.ToInt32(selectedRow.Cells[1].Value);
            stationsTableAdapter.Delete(a, b);
            stationsTableAdapter.Fill(eliteDataSet.stations);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            stationsTableAdapter.Update(eliteDataSet.stations);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedCells.Count <= 0) return;
            var selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;

            var selectedRow = dataGridView4.Rows[selectedrowindex];

            var a = Convert.ToInt32(selectedRow.Cells[0].Value);

            itemsTableAdapter.Delete(a);
            itemsTableAdapter.Fill(eliteDataSet.items);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            itemsTableAdapter.Update(eliteDataSet.items);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedCells.Count <= 0) return;
            var selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;

            var selectedRow = dataGridView5.Rows[selectedrowindex];

            tradeitemsTableAdapter.Delete(Convert.ToInt32(selectedRow.Cells[0].Value), Convert.ToInt32(selectedRow.Cells[1].Value), Convert.ToInt32(selectedRow.Cells[2].Value), selectedRow.Cells[3].Value as int?, selectedRow.Cells[4].Value as int?, selectedRow.Cells[5].Value as int?, selectedRow.Cells[6].Value as DateTime?);
            tradeitemsTableAdapter.Fill(eliteDataSet.tradeitems);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            tradeitemsTableAdapter.Update(eliteDataSet.tradeitems);
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count <= 0) return;
            var selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;

            var selectedRow = dataGridView3.Rows[selectedrowindex];

            var a = Convert.ToInt32(selectedRow.Cells[0].Value);

            tradeitemsTableAdapter.FillByStationID1(eliteDataSet.tradeitems, a);
        }

        private void Form1_Move(object sender, EventArgs e)
        {

            var t = Top;
            var l = Left;

            if (_showSystemName == null) return;

            _showSystemName.DesktopLocation = new Point(l + 100, t + 100);

        }
    }
}