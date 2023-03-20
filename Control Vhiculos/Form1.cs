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
using System.Net.NetworkInformation;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Control_Vhiculos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Vehiculo> Carro = new List<Vehiculo>();
        List<Clientes> cl = new List<Clientes>();
        List<Alquiler> alq = new List<Alquiler>();

        void Guardar()
        {
            
          
            StreamWriter writer = new StreamWriter("Guardar.txt");

            try
            {
                writer.WriteLine(textBox1.Text);
                writer.WriteLine(textBox2.Text);
                writer.WriteLine(textBox3.Text);
                writer.WriteLine(textBox4.Text);
                writer.WriteLine(textBox5.Text);
            }
            catch
            {
                MessageBox.Show("Error");
            }

            writer.Close();

        }
        
        void Leer()
        {
            
            FileStream stream = new FileStream("Guardar.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Placa1 = (reader.ReadLine());
                vehiculo.Marca1 = (reader.ReadLine());
                vehiculo.Modelo1 = (reader.ReadLine());
                vehiculo.Color1 = (reader.ReadLine());
                vehiculo.Precio1 = Convert.ToInt32(reader.ReadLine());
                
                Carro.Add(vehiculo);
            }

            reader.Close();

        }

        void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Carro;
            dataGridView1.Refresh();

        }

        private void BotonIngresarVehiculos_Click(object sender, EventArgs e)
        {
            Guardar();
            Leer();
            Mostrar();
             textBox1.Clear();
             textBox2.Clear();
             textBox3.Clear();
             textBox4.Clear();
             textBox5.Clear();
        }

        void LeerDatosClientes()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
                Clientes cliente = new Clientes();
                cliente.Nit = reader.ReadLine();
                cliente.Nombre1 = reader.ReadLine();
                cliente.Direccion = reader.ReadLine();

                cl.Add(cliente);
            }

            reader.Close();

        }

        void MostrarDatosCliente()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = cl;
            dataGridView2.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerDatosClientes();
            MostrarDatosCliente();
        }

        void LeerDatosAlquiler()
        {
            FileStream stream = new FileStream("Alquiler.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Alquiler alquiler = new Alquiler();     
                alquiler.Nit = reader.ReadLine();
                alquiler.Placa1 = reader.ReadLine();
                alquiler.FechaAlq1 = reader.ReadLine();
                alquiler.FechaDev1 = reader.ReadLine();
                alquiler.KilometrosRec1 = Convert.ToInt32(reader.ReadLine());
                alq.Add(alquiler);

            }

            reader.Close();
        }
        void MostrarDatosAlq()
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource= Renta;
            dataGridView3.Refresh();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LeerDatosAlquiler();
            Comparar();
            MostrarDatosAlq();

            label10.Visible = true;
            
        }
        List<CarrosRentados> Renta = new List<CarrosRentados>();
        
        void Comparar()

        {
            for(int i = 0; i < alq.Count; i++)
            {
                CarrosRentados carrosRentados = new CarrosRentados();

                carrosRentados.FechaDev1 = alq[i].FechaDev1;


                for(int j=0; j<Carro.Count; j++)
                {
                    if (alq[i].Placa1 == Carro[j].Placa1)
                    {
                        carrosRentados.Placa1 = Carro[j].Placa1;
                        carrosRentados.Marca1 = Carro[j].Marca1;
                        carrosRentados.Modelo1 = Carro[j].Modelo1;
                        carrosRentados.Color1 = Carro[j].Color1;
                        carrosRentados.Precio1 = Carro[j].Precio1;
                        carrosRentados.Total1 = alq[i].KilometrosRec1 * carrosRentados.Precio1;
                        

                    }
                }
                for(int k = 0; k<cl.Count; k++)
                {
                    if (alq[i].Nit == cl[k].Nit)
                    {
                        carrosRentados.Nombre1 = cl[k].Nombre1;
                    }

                }

                Renta.Add(carrosRentados);
            }
        }
    }
}
