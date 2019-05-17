using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Library;

namespace Sell_ArrayAndFile_FormApp
{
    //A103223013_FinalExam_翁華威 8/Jan/2015
    public partial class saleBookForm : Form
    {
        Check ToCheck = new Check();
        CountBook ToCount = new CountBook();
        SaveAndReadFile ToFile = new SaveAndReadFile();
        SaleRecord SaleRecord;

        public Label[] Product_Labels;
        public TextBox[] Product_TextBoxes;
        public TextBox[] Price_TextBoxes;

        public string[] EmployeeIDs;
        public string[] FirstNames;
        public string[] LastNames;
        public int[] ProductArray;
        public int[] PriceArray;
        public int[] SaleArray;

        const int SALE_Target = 40000;
        bool writeOn = false;
        bool readOn = false;

        public string Company;
        public int EmployeeNumber, ProductNumber;
        int times = 0;
        int result;

        int Pass = 0;
        int Fail = 0;
        int OverAve = 0;
        int UnderAve = 0;

        public saleBookForm()
        {
            InitializeComponent();
            readFileGroupBox.Visible = false;
            DoneFileStreamGroupBox.Visible = false;
            select1RecordGroupBox.Visible = false;
            dataInputGroupBox.Visible = false;
            resultGroupBox.Visible = false;
            saleLevelGB.Visible = false;
            startInputGroupBox.Visible = false;
            basicDataGroupBox.Visible = false;

            SaleRecord ToRecord = new SaleRecord();
            AllTextBoxAndLabels();
        }

        private void InputRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            basicDataGroupBox.Visible = true;
            writeOn = true;
        }

        private void ReadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            basicDataGroupBox.Visible = true;
            readOn = true;
        }

        private void saveDirBtn_Click(object sender, EventArgs e)
        {
            if (writeOn)
            {
                if (saveFileDialog_sale.ShowDialog() == DialogResult.OK)
                {
                    fileNameTextBox.Text = saveFileDialog_sale.FileName;
                    openFileDialogpictureBox.Visible = true;
                    saveDirBtn.Enabled = false;
                }
            }
            else 
            {
                if(openFileDialog_sale.ShowDialog()==DialogResult.OK)
                {
                    fileNameTextBox.Text = openFileDialog_sale.FileName;
                    openFileDialogpictureBox.Visible = true;
                    saveDirBtn.Enabled = false;
                }
            }
        }

        private void exitPctureBox_Click(object sender, EventArgs e)
        {
            //if (writeOn) ToFile.fileWriter.Close();
            //else ToFile.fileReader.Close();
            this.Close();
        }

        private void openFileDialogpictureBox_Click(object sender, EventArgs e)
        {
            if (writeOn)
            {
                ToFile.fileWriter = File.AppendText(saveFileDialog_sale.FileName);
                MessageBox.Show("開檔成功(存檔)");

                //顯示

                companyTextBox.Enabled = true;
                totalEmployeeTextBox.Enabled = true;
                productCatogoriesTextBox.Enabled = true;
                textBox_TargetSale.Text = "40000";
                startInputGroupBox.Visible = true;
            }
            else
            {
                ToFile.fileReader = File.OpenText(openFileDialog_sale.FileName);
                MessageBox.Show("開檔成功(讀檔)");
                readFileGroupBox.Visible = true;
            }
        }

        private void starIinputPictureBox_Click(object sender, EventArgs e)
        {
            bool checkCompany = false, checkEmployee = false, checkProductNo = false;
            checkCompany = ToCheck.checkstring(companyTextBox.Text);
            checkEmployee = ToCheck.checkint(totalEmployeeTextBox.Text, -1, 999999, 1);
            checkProductNo = ToCheck.checkint(productCatogoriesTextBox.Text, 0, 11, 1);

            if (checkCompany) Company = companyTextBox.Text;
            else MessageBox.Show("公司名稱錯誤，請重新輸入");

            if (checkEmployee) EmployeeNumber = int.Parse(totalEmployeeTextBox.Text);
            else
            {
                MessageBox.Show("員工人數輸入錯誤，請重新輸入");
                totalEmployeeTextBox.Text = string.Empty;
            }

            if (checkProductNo) ProductNumber = int.Parse(productCatogoriesTextBox.Text);
            else
            {
                MessageBox.Show("手機產品種類輸入錯誤，請重新輸入");
                productCatogoriesTextBox.Text = string.Empty;
            }

            if(checkCompany&&checkEmployee&&checkProductNo)
            {
                MessageBox.Show("成功，開始輸入資料");
                dataInputGroupBox.Visible = true;
                basicDataGroupBox.Enabled = false;
                startInputGroupBox.Enabled = false;

                EmployeeIDs = new string[EmployeeNumber];
                LastNames = new string[EmployeeNumber];
                FirstNames = new string[EmployeeNumber];
                ProductArray = new int[EmployeeNumber];
                PriceArray = new int[EmployeeNumber];
                SaleArray = new int[EmployeeNumber];

                SaleRecord =new SaleRecord(Company, EmployeeNumber.ToString(), ProductNumber.ToString());
                ShowTextboxesAndLabels();
                OutputResultListBox.Items.Add("ID\t\t名\t姓\t銷售業績");
            }
        }

        private void writerPictureBox_Click(object sender, EventArgs e)
        {
            // 偵錯 //

            bool checkID = false, checkFirstName = false, checkLastName = false;
            bool checkProduct = false, AllProductOK = true, checkPrice = false, AllPriceOK = true;

            checkID = ToCheck.checkstring(textBox_ID.Text);
            if(!checkID)
            {
                MessageBox.Show("ID輸入錯誤！");
                textBox_ID.Text = string.Empty;
            }
            checkFirstName = ToCheck.checkstring(textBox_FirstName.Text);
            if(!checkFirstName)
            {
                MessageBox.Show("名輸入錯誤！");
                textBox_FirstName.Text = string.Empty;
            }
            checkLastName = ToCheck.checkstring(textBox_LastName.Text);
            if(!checkLastName)
            {
                MessageBox.Show("姓輸入錯誤！");
                textBox_LastName.Text = string.Empty;
            }
            
            for(int count=0;count<ProductNumber;count++)
            {
                checkProduct = ToCheck.checkint(Product_TextBoxes[count].Text, -1, 999999, 1);
                if (checkProduct) ProductArray[count] = int.Parse(Product_TextBoxes[count].Text);
                else
                {
                    MessageBox.Show("第 "+ (count+1) +" 項產品數量輸入錯誤！");
                    Product_TextBoxes[count].Text = string.Empty;
                    AllProductOK = false;
                }
            }

                for (int count = 0; count < ProductNumber; count++)
                {
                    checkPrice = ToCheck.checkint(Price_TextBoxes[count].Text, -1, 99999999, 1);
                    if (checkPrice)
                    {
                        Price_TextBoxes[count].Enabled = false;
                        PriceArray[count] = int.Parse(Price_TextBoxes[count].Text);
                    }
                    else
                    {
                        MessageBox.Show("第 " + (count + 1) + " 項產品單價輸入錯誤！");
                        Price_TextBoxes[count].Text = string.Empty;
                        AllPriceOK = false;
                    }
                }

            // 偵錯結束

            if(checkID && checkLastName &&checkFirstName&&AllProductOK&&AllPriceOK)
            {
                EmployeeIDs[times] = textBox_ID.Text;
                LastNames[times] = textBox_LastName.Text;
                FirstNames[times] = textBox_FirstName.Text;
                SaleArray[times] = SaleResult(PriceArray, ProductArray);

                OutputResultListBox.Items.Add(EmployeeIDs[times] + "\t" + FirstNames[times] + "\t" + LastNames[times] + "\t" + SaleArray[times]);
                ++times;
                ClearInputData();
            }

            if (times == EmployeeNumber)
            {
                dataInputGroupBox.Enabled = false;
                resultGroupBox.Visible = true;
                saleLevelGB.Visible = true;
            }
        }

        private void computePictureBox_Click(object sender, EventArgs e)
        {
            SaleRecord ToRecord = new SaleRecord();
            computePictureBox.Enabled = false;

            ToCount.GradesArray(SaleArray);

            CountPassOrFail(SaleArray, SALE_Target);
            CountOverOrUnderAverage(SaleArray, ToCount.GetAverage());

            totalTextBox.Text = EmployeeNumber.ToString();
            AveTextBox.Text = ToCount.GetAverage().ToString();
            minTextBox.Text = ToCount.GetMinimum().ToString();
            maxTextBox.Text = ToCount.GetMaximum().ToString();
            passTextBox.Text = GetPass().ToString();
            failTextBox.Text = GetFail().ToString();
            overTextBox.Text = GetOverAve().ToString();
            underTextBox.Text = GetUnderAve().ToString();
            A_textBox.Text = ToCount.GetA_Level().ToString();
            B_textBox.Text = ToCount.GetB_Level().ToString();
            C_textBox.Text = ToCount.GetC_Level().ToString();
            D_textBox.Text = ToCount.GetD_Level().ToString();
            F_textBox.Text = ToCount.GetF_Level().ToString();

            SaleRecord =new SaleRecord(SALE_Target.ToString(),GetPass().ToString(),GetFail().ToString(),ToCount.GetAverage().ToString(),ToCount.GetMaximum().ToString(),ToCount.GetMinimum().ToString(),GetOverAve().ToString(),GetUnderAve().ToString());
            ToRecord.SetArray(EmployeeIDs, FirstNames, LastNames, SaleArray);
       //     SaleRecord.OutputSales();
            SaleRecord.Display();
            MessageBox.Show(SaleRecord.show);
            DoneFileStreamGroupBox.Visible = true;
        }

        private void endFileStreamPictureBox_Click(object sender, EventArgs e)
        {
            CloseFile();
            MessageBox.Show("關檔成功");
        }

        private void ShowTextboxesAndLabels()
        {
            for (int count = 0; count < ProductNumber; count++)
            {
                Product_TextBoxes[count].Visible = true;
                Product_Labels[count].Visible = true;
                Price_TextBoxes[count].Visible = true;
            }
        } // 顯示輸入格子

        private void AllTextBoxAndLabels()
        {
            Product_Labels = new Label[] { product1_Label, product2_Label, product3_Label, product4_Label, product5_Label, product6_Label, product7_Label, product8_Label, product9_Label, product10_Label };
            Product_TextBoxes = new TextBox[] { textBox_Product1, textBox_Product2, textBox_Product3, textBox_Product4, textBox_Product5, textBox_Product6, textBox_Product7, textBox_Product8, textBox_Product9, textBox_Product10 };
            Price_TextBoxes = new TextBox[] { textBox_Price1, textBox_Price2, textBox_Price3, textBox_Price4, textBox_Price5, textBox_Price6, textBox_Price7, textBox_Price8, textBox_Price9, textBox_Price10 };
        } // 陣列化輸入資料

        private void ClearInputData()
        {
            textBox_ID.Text = string.Empty;
            textBox_LastName.Text = string.Empty;
            textBox_FirstName.Text = string.Empty;
            for(int count=0;count<ProductNumber;count++)
            {
                Product_TextBoxes[count].Text = string.Empty;
            }
        } // 消除輸入資料

        public int SaleResult(int[] price,int[] amount)
        {
            result = 0;
            for (int count = 0; count < ProductNumber; count++)
            {
                result += price[count] * amount[count];
            }
            return result;
        } // 計算個人總業績

        public void CountPassOrFail(int[] resultArray,int saleTarget)
        {
            for (int count = 0; count < resultArray.Length; count++)
            {
                if (resultArray[count] >= saleTarget) Pass += 1;
                else Fail += 1;
            }
        }

        public void CountOverOrUnderAverage(int[] resultArray,int average)
        {
            for(int count=0;count<resultArray.Length;count++)
            {
                if (resultArray[count] >= average) OverAve += 1;
                else UnderAve += 1;
            }
        }

        public int GetPass() { return Pass; }
        public int GetFail() { return Fail; }
        public int GetOverAve() { return OverAve; }
        public int GetUnderAve() { return UnderAve; }

        public void CloseFile()
        {
            if (writeOn)
            {
                ToFile.fileWriter.WriteLine(SaleRecord.show);
                ToFile.fileWriter.Close();
            }
            else
            {
                ToFile.fileReader.Close();
            }
        }

        private void readFilePictureBox_Click(object sender, EventArgs e)
        {
            if(openFileDialog_sale.ShowDialog()==DialogResult.OK)
            {
                ToFile.fileReader = File.OpenText(openFileDialog_sale.FileName);
                while(!ToFile.fileReader.EndOfStream)
                {
                    OutputResultListBox.Items.Clear();
                    OutputResultListBox.Items.Add(ToFile.fileReader.ReadLine());
                }
            }
            
        }
    }
}
