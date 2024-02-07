using Microsoft.Data.SqlClient;

namespace vizsgafeladat
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Load += frmMain_Load;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            using SqlConnection connection = new(Program.connectionString);
            connection.Open();

            SqlCommand command = new("SELECT ev,nev FROM kituntetes " +
                "INNER JOIN szemely " +
                "ON kituntetes.szemelyID = szemely.ID " +
                "ORDER BY ev DESC, nev ASC;", connection);

            SqlDataReader reader = command.ExecuteReader();
            int index = 0;
            while (reader.Read()) 
            { int ev=reader.GetInt32(0);
                dgvDijazottak.Rows.Add(reader[0], reader[1]);
                if (ev % 2 == 0) 
                {
                    dgvDijazottak.Rows[index].DefaultCellStyle.BackColor = Color.LightCoral;
                }
             
            
                    index++;
            }
        }
    }
}