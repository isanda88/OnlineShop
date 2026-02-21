using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing.Printing;

namespace masiniii
{

    public partial class Form1 : Form
    {
        // XML
        Dictionary<string, List<Produs>> produseCategorii = new Dictionary<string, List<Produs>>();
        private static int orderID = 1;

        public Form1()
        {
            InitializeComponent(); //nu cred ca e neaparat, n am incarcare din fisierul text
            IncarcaProduseDinXML("XML.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lista1.Items.Clear();
            lista2.Items.Clear();
            lista1.Enabled = false;
            lista2.Enabled = false;
            combo1.Text = "Alimentare";
            combo1.Items.Add("Fructe");
            combo1.Items.Add("Legume");
            combo1.Items.Add("Lactate");
            combo1.Items.Add("Uleiuri");
            combo1.Items.Add("Patiserie");

            combo2.Text = "Nealimentare";
            combo2.Items.Add("Imbracaminte");
            combo2.Items.Add("Incaltaminte");
            combo2.Items.Add("Detergent");
            combo2.Items.Add("Papetarie");
            combo2.Items.Add("Lenjerii_pat");


            dataGridView1.Columns.Add("" ,"Marfa disponibila");
            dataGridView1.Columns.Add("","Cantitate"); // fara ele nu apar stocurile avute

            AfiseazaStocuri();
        }


        private void AfiseazaStocuri()
        {

            dataGridView1.Rows.Clear();

            // fiecare produs și cantitatea avuta in dictiionarul produseCategorii in DataGridView
            foreach (var categorie in produseCategorii)
            {
                foreach (var produs in categorie.Value)
                {
                    dataGridView1.Rows.Add(produs.Nume, produs.Cantitate);
                }
            }
        }

        public class Produs
        {
            

            public string Nume { get; set; }
            public decimal Pret { get; set; }
            public DateTime? TermenExpirare { get; set; }
            public string CodIdentificare { get; set; }
            public int Cantitate { get; set; }
            public string Descriere { get; set; }


            public Produs(string nume, decimal pret, DateTime? termenExpirare, string codIdentificare, int cantitate, string descriere)
            {
                Nume = nume;
                Pret = pret;
                TermenExpirare = termenExpirare;
                CodIdentificare = codIdentificare;
                Cantitate = cantitate;
                Descriere = descriere;
            }

            public override string ToString()
            {
                if (TermenExpirare.HasValue)
                {
                    return $"{Nume} - {Pret} lei - Expira la {TermenExpirare.Value.ToShortDateString()} - Cod: {CodIdentificare} - Descriere: {Descriere}";
                }
                else
                {
                    return $"{Nume} - {Pret} lei - Cod: {CodIdentificare} - Descriere: {Descriere}";
                }
            }
        }

        private void IncarcaProduseDinXML(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);

            foreach (var categorie in doc.Root.Elements("Categorie"))
            {
                string categorieNume = categorie.Attribute("Nume").Value;
                List<Produs> produse = new List<Produs>();

                foreach (var produsElement in categorie.Elements("Produs"))
                {
                    string nume = produsElement.Attribute("Nume").Value;

                    decimal pret = decimal.Parse(produsElement.Attribute("Pret").Value);

                    int cantitate = int.Parse(produsElement.Attribute("Cantitate").Value);

                    string codIdentificare = Guid.NewGuid().ToString().Substring(0, 8);

                    DateTime? termenExpirare = null;

                    string descriere = produsElement.Attribute("Descriere").Value;

                    if (produsElement.Attribute("TermenExpirare") != null)
                    {
                        termenExpirare = DateTime.Parse(produsElement.Attribute("TermenExpirare").Value);
                    }

                    produse.Add(new Produs(nume, pret, termenExpirare, codIdentificare, cantitate, descriere));
                }

                produseCategorii.Add(categorieNume, produse);
            }
        }
        //alim
        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = combo1.SelectedItem.ToString();

            if (produseCategorii.ContainsKey(selectedCategory))
            {
                foreach (var produs in produseCategorii[selectedCategory])
                {
                    lista1.Items.Add(produs.Nume);
                }
            }

            lista1.Enabled = true;
            lista2.Enabled = false;
            butonAdauga.Enabled = false;
            butonSterge.Enabled = false;
        }
        //nealim
        private void combo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = combo2.SelectedItem.ToString();

            if (produseCategorii.ContainsKey(selectedCategory))
            {
                foreach (var produs in produseCategorii[selectedCategory])
                {
                    lista1.Items.Add(produs.Nume);
                }
            }

            lista1.Enabled = true;
            lista2.Enabled = false;
            butonAdauga.Enabled = false;
            butonSterge.Enabled = false;
        }

        private void lista1_SelectedIndexChanged(object sender, EventArgs e)
        {
            butonAdauga.Enabled = true;
        }

        private void lista2_SelectedIndexChanged(object sender, EventArgs e)
        {
            butonSterge.Enabled = true;
        }

        private void butonAdauga_Click(object sender, EventArgs e)
        {
            lista2.Enabled = true;

            foreach (var selectedIndex in lista1.SelectedIndices)
            {
                string produsNume = lista1.Items[(int)selectedIndex].ToString();// produsul selectat
                Produs selectedProdus = null;//intai 0, apoi pot selecta cate vreau

                foreach (var categorie in produseCategorii)
                {
                    selectedProdus = categorie.Value.FirstOrDefault(p => p.Nume == produsNume);
                    if (selectedProdus != null)
                    {
                        break;
                    }
                }

                if (selectedProdus != null)
                {
                    lista2.Items.Add(selectedProdus.ToString());
                }
            }
        }

        private void butonCalculeaza_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (var item in lista2.Items)
            {
                string text = item.ToString();
                
                //extrag partea cu pretul
                int startIndex = text.IndexOf('-') + 1;
                int endIndex = text.IndexOf(" lei");

                if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
                {    // adica niciun element la -1
                    string priceString = text.Substring(startIndex, endIndex - startIndex).Trim();

                    if (decimal.TryParse(priceString, out decimal price))
                    {
                        total += price;   // se calculeaza pretul
                    }
                }
            }

            labelTotal.Text = $"Total: {total} lei";
        }

        private void butonSterge_Click(object sender, EventArgs e)
        {
            while (lista2.SelectedIndices.Count > 0)
            {
                lista2.Items.RemoveAt(lista2.SelectedIndices[0]);
            }
            if (lista2.Items.Count == 0)
                lista2.Enabled = false;
            butonSterge.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        //
        private void plaseazaComanda_Click(object sender, EventArgs e)
        {
            int currentOrderID = orderID++;
            string filePath = $"Comanda_{currentOrderID}.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"ID Client: {currentOrderID}");

                foreach (var item in lista2.Items)
                {
                    string text = item.ToString();
                    int codIndexStart = text.IndexOf("Cod: ") + 5;
                    string codProdus = text.Substring(codIndexStart, 8);

                    string[] parts = text.Split(new[] { " - " }, StringSplitOptions.None);
                    string numeProdus = parts[0];
                    Produs selectedProdus = produseCategorii.Values.SelectMany(p => p).FirstOrDefault(p => p.Nume == numeProdus);


                    if (selectedProdus != null)
                    {
                        
                        selectedProdus.Cantitate--;

                        
                        AfiseazaStocuri();

                        
                        writer.WriteLine($"{codProdus}/{selectedProdus.Cantitate}");
                    }
                }
            }

            MessageBox.Show($"Comanda a fost plasată cu succes! Fișierul comenzii: {filePath}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void labelTotal_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Doriți să generați factura?", "Generare Factură", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                PrintDocument printDocument = new PrintDocument();

               
                string logoPath = @"C:\Users\sandu\Downloads\poza.png";

                
                if (!File.Exists(logoPath))
                {
                    MessageBox.Show("Fișierul logo nu poate fi găsit. Se va folosi un logo alternativ.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                    logoPath = ""; 
                }

                //  evenimentul de desenare a facturii in doc
                printDocument.PrintPage += (s, ev) =>
                {
                    //font si pensula
                    Font fontTitlu = new Font("Arial", 14, FontStyle.Bold);
                    Font fontText = new Font("Arial", 10);
                    SolidBrush brush = new SolidBrush(Color.Black);

                    
                    int startXFurnizor = 150;
                    int startYFurnizor = 120;
                    int offsetFurnizor = 20;

                    // inf furnizor st
                    ev.Graphics.DrawString("Furnizor", fontTitlu, brush, startXFurnizor, startYFurnizor);
                    ev.Graphics.DrawString("Nume Furnizor: Ioana Sandu", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 1);
                    ev.Graphics.DrawString("Nr. Reg. Com: J22/02/2212", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 2);
                    ev.Graphics.DrawString("CIF: 56789", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 3);
                    ev.Graphics.DrawString("Adresa: UAIC", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 4);
                    ev.Graphics.DrawString("Email: sanduioana175@gmail.com", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 5);
                    ev.Graphics.DrawString("Tel: 0784722157", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 6);
                    ev.Graphics.DrawString("Banca: TRANSILVANIA", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 7);
                    ev.Graphics.DrawString("CONT: ROBTRL2536383929298", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 8);

                    
                    int startXClient = 400; //deplasare inspre dr
                    int startYClient = 140; 
                    int offsetClient = 20; //spatiere

                    // inf client dr
                    ev.Graphics.DrawString("Client", fontTitlu, brush, startXClient, startYClient);
                    ev.Graphics.DrawString("Nume Client: Popescu Mihai", fontText, brush, startXClient, startYClient + offsetClient * 1);
                    ev.Graphics.DrawString("Nr. Reg. Com.: J33/223/222", fontText, brush, startXClient, startYClient + offsetClient * 2);
                    ev.Graphics.DrawString("CIF: 67456", fontText, brush, startXClient, startYClient + offsetClient * 3);
                    ev.Graphics.DrawString("Email: popescumihai@gmail.com", fontText, brush, startXClient, startYClient + offsetClient * 4);
                    ev.Graphics.DrawString("Tel: 07843663657", fontText, brush, startXClient, startYClient + offsetClient * 5);
                    ev.Graphics.DrawString("Banca: BCR", fontText, brush, startXClient, startYClient + offsetClient * 6);
                    ev.Graphics.DrawString("CONT: RONBTRB0987654321", fontText, brush, startXClient, startYClient + offsetClient * 7);
                    //mergem in jos cu 1,2,3,4,5...




                    // inf factura
                    ev.Graphics.DrawString("Factura seria: F  nr.: 1 data: 20.06.2024", fontTitlu, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 10);
                    ev.Graphics.DrawString("Cota TVA: 19%", fontText, brush, startXFurnizor, startYFurnizor + offsetFurnizor * 11);

                    // un fel de tabel
                    int startXTable = 50;
                    int startYTable = startYFurnizor + offsetFurnizor * 13;
                    int offsetTable = 20;  

                    

                    // un fel de tabel-inceput
                    ev.Graphics.DrawString("Produs", fontTitlu, brush, startXTable, startYTable);
                    ev.Graphics.DrawString("Cantitate", fontTitlu, brush, startXTable + 200, startYTable);
                    ev.Graphics.DrawString("Pret Unitar", fontTitlu, brush, startXTable + 350, startYTable);
                    ev.Graphics.DrawString("Valoare", fontTitlu, brush, startXTable + 500, startYTable);



                    // de unde incep celelalte inf
                    startYTable += offsetTable;

                    
                    decimal totalFaraTVA = 0;
                    decimal totalTVA = 0;
                    decimal totalCuTVA = 0;

                    foreach (var item in lista2.Items)
                    {

                        // aici se dau elementele afisate


                        string text = item.ToString();

                        string[] parts = text.Split(new[] { " - " }, StringSplitOptions.None);




                     

                        // formatl corect, adica daca s ok acele elemente din lista 2
                        if (parts.Length >= 2)



                        {   //despartirea pe parti
                            string numeProdus = parts[0];
                            string pretText = parts[1].Split(' ')[0];
                            decimal pretUnitar;
                             
                            if (decimal.TryParse(pretText, out pretUnitar))
                            {
                                int cantitate = 1; 

                                
                                decimal valoare = cantitate * pretUnitar;
                                decimal valoareTVA = valoare * 0.19m; 

                                
                                totalFaraTVA += valoare;
                                totalTVA += valoareTVA;
                                totalCuTVA += valoare + valoareTVA;

                                // Desenam detaliile în tabel
                                ev.Graphics.DrawString(numeProdus, fontText, brush, startXTable, startYTable);
                                ev.Graphics.DrawString(cantitate.ToString(), fontText, brush, startXTable + 200, startYTable);
                                ev.Graphics.DrawString(pretUnitar.ToString("F2") + " lei", fontText, brush, startXTable + 350, startYTable);
                                ev.Graphics.DrawString(valoare.ToString("F2") + " lei", fontText, brush, startXTable + 500, startYTable);

                                startYTable += offsetTable;
                            }
                            else
                            {
                                MessageBox.Show($"Prețul '{pretText}' pentru produsul '{numeProdus}' nu este într-un format numeric valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Formatul elementului '{text}' în lista2 nu este corect.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Desenam inf
                    ev.Graphics.DrawString($"Total fără TVA: {totalFaraTVA.ToString("F2")} lei", fontTitlu, brush, startXTable + 300, startYTable);
                    ev.Graphics.DrawString($"TVA: {totalTVA.ToString("F2")} lei", fontTitlu, brush, startXTable + 300, startYTable + offsetTable);
                    ev.Graphics.DrawString($"Total cu TVA: {totalCuTVA.ToString("F2")} lei", fontTitlu, brush, startXTable + 300, startYTable + 2 * offsetTable);

                       //adica daca nu am sursa pozei
                    if (!string.IsNullOrEmpty(logoPath))
                    {
                        Image logo = Image.FromFile(logoPath);
                        ev.Graphics.DrawImage(logo, new Rectangle(50, 50, 100, 100));
                    }
                };

                // Afisam dialogul de previzualizare a printarii
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();
            }
        }



    }
}


/*SURSE BIBLIOGRAFICE:  

 Tutoriale pe net https://www.youtube.com/watch?v=8GSNRkiSPrc&t=400s
 Lab4- legaturi si interfata grafica(masiniii)
 Lab11- Stocuri - xml etc
 Elemente grafice - https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics?view=net-8.0
                  - file:///C:/Users/sandu/OneDrive/Desktop/Facultate/POO/L08.%20Laborator%208%20(1).pdf


 


*/

