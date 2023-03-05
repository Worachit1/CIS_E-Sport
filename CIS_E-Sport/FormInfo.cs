namespace CIS_E_Sport
{
    public partial class FormInfo : Form
    {
        private Player _newPlayer;
        public FormInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string lastname = tbLastname.Text;
            string studentid = tbID.Text;
            string major = tbMajor.Text;
            string displayname = tbDisplay.Text;
            string mail = tbEmail.Text;
            string phone = tbPhoneNumber.Text;
            string team = tbTeam.Text;
            int iAge = 0;
            try
            {
                string age = tbAge.Text;
                iAge = Int32.Parse(age);
            }
            catch (FormatException ex)
            {
                //Do somthing if have some exception
                MessageBox.Show("คุณใส่ข้อมูลไม่ถูกต้อง");
                return;
            }

            _newPlayer = new Player(name, lastname, studentid, 
                major, displayname, mail, phone, iAge , team);

            this.DialogResult = DialogResult.OK;
            
        }
        public Player getPlayer() { return _newPlayer; }
    }
}