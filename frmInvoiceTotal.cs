namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        // TODO: declare class variables for array and list here

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InvoiceTotal
    {
        public partial class frmInvoiceTotal : Form
        {
            // ✅ CLASS VARIABLES (Step 2)
            private decimal[] invoiceTotals = new decimal[5];
            private int index = 0;

            private List<decimal> invoiceList = new List<decimal>();

            public frmInvoiceTotal()
            {
                InitializeComponent();
            }

            private void btnCalculate_Click(object sender, EventArgs e)
            {
                try
                {
                    if (txtSubtotal.Text == "")
                    {
                        MessageBox.Show("Subtotal is a required field.", "Entry Error");
                    }
                    else
                    {
                        decimal subtotal = Decimal.Parse(txtSubtotal.Text);

                        if (subtotal > 0 && subtotal < 10000)
                        {
                            decimal discountPct = .25m;
                            decimal discountAmt = Math.Round(subtotal * discountPct, 2);
                            decimal invoiceTotal = Math.Round(subtotal - discountAmt, 2);

                            txtDiscountPct.Text = discountPct.ToString("p1");
                            txtDiscountAmt.Text = discountAmt.ToString("c");
                            txtTotal.Text = invoiceTotal.ToString("c");

                            // ✅ STORE VALUES (Step 3)
                            invoiceTotals[index] = invoiceTotal;
                            invoiceList.Add(invoiceTotal);
                            index++;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Subtotal must be greater than 0 and less than 10,000.",
                                "Entry Error");
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("You can only enter up to 5 invoices.", "Limit Reached");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid number for the Subtotal field.", "Entry Error");
                }

                txtSubtotal.Focus();
            }

            private void btnExit_Click(object sender, EventArgs e)
            {
             
                Array.Sort(invoiceTotals);
                string message = "";

                foreach (decimal total in invoiceTotals)
                {
                    if (total != 0)
                    {
                        message += total.ToString("c") + "\n";
                    }
                }

                MessageBox.Show(message, "Order Totals - Array");

                
                string listMessage = "";

                foreach (decimal total in invoiceList)
                {
                    listMessage += total.ToString("c") + "\n";
                }

                MessageBox.Show(listMessage, "Order Totals - List");

                this.Close();
            }
        }
    }