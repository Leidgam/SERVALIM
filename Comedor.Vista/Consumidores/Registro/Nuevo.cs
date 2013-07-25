using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comedor.Control;
using Comedor.Modelo;
using System.IO;
using Comedor.Modelo.Auxiliares;

namespace Comedor.Vista.Consumidores
{
    public partial class Nuevo : Form
    {

        #region constructor
        public Nuevo()
        {
            InitializeComponent();
        }

        #endregion

        #region declaraciones
        List<Pais> paises;
        m_Pais _mPais = new m_Pais();

        List<Facultad> facultades;
        m_Facultad _mFacultad = new m_Facultad();

        List<Grupo> grupos;
        m_Grupo _mGrupo = new m_Grupo();

        List<Area> areas;
        m_Area _mArea = new m_Area();

        List<Periodo> periodos;
        m_Periodo _mPeriodo = new m_Periodo();

        public Persona persona = new Persona();
        public consumidor consumidor = new consumidor();

        m_consumidor _mConsumidor = new m_consumidor();

        public Usuario usuario;
        public Periodo periodo;
        Image foto;

        //Editando
        public bool editando = false;
        
        //Usuario
        public bool _userMNT = false;
        public bool _editUser = false;
        public Usuario _mntUsuario = new Usuario();
        m_Usuario _mUsuario = new m_Usuario();
        #endregion

        #region metodos propios

        private void Iniciar()
        {
            cargarBD();
            cargarCombos();
            cmbPais.SelectedIndex = 174;
            cmbDepartamento.SelectedIndex = 14;
            cmbTipoCont.SelectedIndex = 0;
            cmbDni.SelectedIndex = 0;
            cmbCiclo.SelectedIndex = 0;
            radioAuto.Checked = true;
            if (editando) { cargarDatos(); }
            if (_userMNT) { tabConsumidor.Dispose(); } else { tabUsuario.Dispose(); }
            if (_userMNT && _editUser) { cargarDatosUsuario(); }
        }

        private void cargarBD()
        {
            paises = _mPais.ListarPaises();
            facultades = _mFacultad.ListarFacultades();
            grupos = _mGrupo.ListarAllGrupos();
            areas = _mArea.ListarAllAreas();
            periodos = _mPeriodo.ListarPeriodos();
        }

        private void cargarCombos()
        {
            cmbPais.DataSource = this.paises;
            cmbPais.DisplayMember = "Nombre";

            cmbFacultad.DataSource = this.facultades;
            cmbFacultad.DisplayMember = "Nombre";

            cmbGrupo.DataSource = this.grupos;
            cmbGrupo.DisplayMember = "Nombre";

            cmbArea.DataSource = this.areas;
            cmbArea.DisplayMember = "Nombre";

            cmbPeridos.DataSource = this.periodos;
            cmbPeridos.DisplayMember = "Descripcion";
        }

        private void cargarDepartamentos()
        {
            cmbDepartamento.DataSource = ((Pais)cmbPais.SelectedItem).departamentos;
            cmbDepartamento.DisplayMember = "Nombre";
        }

        private void cargarEscuelas()
        {
            cmbEscuela.DataSource = ((Facultad)cmbFacultad.SelectedItem).escuelas;
            cmbEscuela.DisplayMember = "Nombre";
        }

        public static Image ResizeImage (Image srcImage, int newWidth, int newHeight)
        {

            using (Bitmap imagenBitmap =
               new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics =
                        Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode =
                       SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode =
                       InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode =
                       PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage,
                       new Rectangle(0, 0, newWidth, newHeight),
                       new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                       GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        private void ArreglaDataView(DataGridView dgv)
        {
            if (dgv.Columns.Count > 1) return;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Tipo";
            column.DataPropertyName = "tipo";
            column.Width = 50;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Valor";
            column.DataPropertyName = "valor";
            column.Width = 200;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "Eliminar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.ReadOnly = true;

        }

        private void ArreglaDataViewPeridodos(DataGridView dgv)
        {
            if (dgv.Columns.Count > 1) return;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Periodo";
            column.DataPropertyName = "periodo";
            column.Width = 200;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Contrato";
            column.DataPropertyName = "contrato";
            column.Width = 100;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(column);

            column = new DataGridViewImageColumn();
            column.HeaderText = "";
            column.DataPropertyName = "Eliminar";
            column.Width = 30;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.ReadOnly = true;
            dgv.Columns.Add(column);

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.ReadOnly = true;

        }

        private void ListarContacto()
        {
            dgvContacto.Columns.Clear();
            ArreglaDataView(dgvContacto);
            dgvContacto.Rows.Clear();

            foreach (Contacto item in this.persona.contacto)
            {
                int n = dgvContacto.Rows.Add();
                String Tip="";
                if (item.Tipo == 1) { Tip = "Cel"; } else if (item.Tipo == 2) { Tip = "Tel"; }
                else if (item.Tipo == 3) { Tip = "Fax"; } else if (item.Tipo == 4) { Tip = "Email"; }
                else if (item.Tipo == 5) { Tip = "Otro"; }
                dgvContacto.Rows[n].Cells[0].Value = Tip;
                dgvContacto.Rows[n].Cells[1].Value = item.Valor;
                dgvContacto.Rows[n].Cells[2].Value = Comedor.Vista.Properties.Resources.delete;
            }
        }

        private void ListarPeriodo()
        {
            dgvPeriodos.Columns.Clear();
            ArreglaDataViewPeridodos(dgvPeriodos);
            dgvPeriodos.Rows.Clear();

            foreach (Consumidor_Periodo item in this.consumidor.periodos)
            {
                int n = dgvPeriodos.Rows.Add();
                dgvPeriodos.Rows[n].Cells[0].Value = item.Periodo.Descripcion;
                bool contrato=false;
                if (item.Contrato == 1) { contrato = true; } else if (item.Contrato == 0) { contrato = false; }
                dgvPeriodos.Rows[n].Cells[1].Value = contrato;
                dgvPeriodos.Rows[n].Cells[2].Value = Comedor.Vista.Properties.Resources.delete;
            }
        }

        private void AgregarContacto()
        {
            if (validarContacto())
            {
                Contacto contacto = new Contacto();
                contacto.Tipo = cmbTipoCont.SelectedIndex + 1;
                contacto.Valor = txtValorCont.Text;
                contacto.Descripcion = txtDescripcionCont.Text;
                persona.contacto.Add(contacto);
                ListarContacto();
                txtValorCont.Text = "";
                txtDescripcionCont.Text = "";
                if (editando)
                {
                    cambioConsumidor cc = new cambioConsumidor();
                    cc.agregar = true;
                    cc.contacto = true;
                    cc.eliminar = false;                 
                    cc.periodo = false;
                    cc.contact = contacto;
                    consumidor.cambios.Add(cc);
                }
                if (_userMNT && _editUser)
                {
                    cambioUsuario cu = new cambioUsuario();
                    cu.agregar = true;
                    cu.eliminar = false;
                    cu.contact = contacto;
                    _mntUsuario.cambios.Add(cu);
                }
            }
        }

        private bool validarContacto()
        {
            int select = cmbTipoCont.SelectedIndex;
            if (select == 0 || select == 1 || select ==2)
            {
                try { int.Parse(txtValorCont.Text);  }
                catch (Exception ex) { MessageBox.Show("Valor invalido"); return false; }
            }
            else if (select == 3 || select == 4)
            {
                if (txtValorCont.Text == "" || txtValorCont.Text == null)
                {
                    MessageBox.Show("Valor invalido"); return false;
                }
            }
            return true;
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvContacto.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvContacto.ColumnCount;
        }

        private bool IsValidCellAddressPeriodo(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < dgvPeriodos.RowCount &&
                columnIndex >= 0 && columnIndex <= dgvPeriodos.ColumnCount;
        }

        private void AgregarPeriodo()
        {
            if (validarPeriodo())
            {
                Consumidor_Periodo cp = new Consumidor_Periodo();
                cp.Periodo = (Periodo)cmbPeridos.SelectedItem;
                if (chbContrato.Checked) { cp.Contrato = 1; } else { cp.Contrato = 0; }
                if (radioAuto.Checked) { cp.AutoAsig = true; } else { cp.AutoAsig = false; cp.Codigo = txtCodigo.Text; }
                consumidor.periodos.Add(cp);
                ListarPeriodo();
                if (editando)
                {
                    cambioConsumidor cc = new cambioConsumidor();
                    cc.agregar = true;
                    cc.eliminar = false;
                    cc.contacto = false;
                    cc.periodo = true;
                    cc.cp = cp;
                    consumidor.cambios.Add(cc);
                }
            }
        }

        private bool validarPeriodo()
        {
            foreach (Consumidor_Periodo item in this.consumidor.periodos)
            {
                if (item.Periodo.IdPeriodo.Equals(((Periodo)cmbPeridos.SelectedItem).IdPeriodo))
                {
                    MessageBox.Show("Periodo ya Matriculado");
                    return false;
                }
            }
            if (radioManual.Checked)
            {
                if (txtCodigo.Text.Equals("") || txtCodigo.Text.Length != 3)
                {
                    MessageBox.Show("Codigo Invalido");
                    return false;
                }
                if (_mConsumidor.ValidarCodigo(((Periodo)cmbPeridos.SelectedItem).IdPeriodo, txtCodigo.Text)==false)
                {
                    MessageBox.Show("Codigo ya Ocupado");
                    pictureCheck.Image = Comedor.Vista.Properties.Resources.delete;
                    return false;
                }
            }
            return true;
        }

        private void GuardarConsumidor()
        {
            if (ValidarPersona())
            {
                persona.PrimerNombre = txtPrimerNombre.Text;
                persona.SegundoNombre = txtSegNombre.Text;
                persona.Apellidos = txtApellidos.Text;
                persona.TipoDNI = cmbDni.SelectedIndex + 1;
                persona.DNI = txtDni.Text;
                persona.Pais = (Pais)cmbPais.SelectedItem;
                persona.Departamento = (Departamento)cmbDepartamento.SelectedItem;
                persona.Distrito = txtDistrito.Text;
                persona.FechaNac = dtpFechaNac.Value.Date;

                consumidor.Persona = persona;
            }
            else { return; }

            if (ValidarConsumidor())
            {
                consumidor.EAP = (EAP)cmbEscuela.SelectedItem;
                consumidor.Ciclo = cmbCiclo.SelectedIndex + 1;
                consumidor.CodUniversitario = txtCodUni.Text;
                consumidor.Area = (Area)cmbArea.SelectedItem;
                consumidor.Grupo = (Grupo)cmbGrupo.SelectedItem;
                
                if (editando)
                {
                    consumidor.IdUsuarioMod = this.usuario.IdUsuario;
                    _mConsumidor.Editar(consumidor);
                    if (System.IO.File.Exists(@"\\JMGDIEL\Fotos\Fotos\" + persona.IdPersona + ".jpg"))
                    {
                        // Use a try block to catch IOExceptions, to
                        // handle the case of the file already being
                        // opened by another process.
                        try
                        {
                            System.IO.File.Delete(@"\\JMGDIEL\Fotos\" + persona.IdPersona + ".jpg");
                        }
                        catch (System.IO.IOException e)
                        {
                            MessageBox.Show(e.Message);
                            
                        }
                    }
                    GuardarFoto(persona.IdPersona);
                   
                }
                else
                {
                    consumidor.IdUsuarioReg = this.usuario.IdUsuario;
                    String idPersona = _mConsumidor.AgregarConsumidor(consumidor);
                    GuardarFoto(idPersona);
                }
                DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void GuardarUsuario()
        {
            if (ValidarPersona())
            {
                persona.PrimerNombre = txtPrimerNombre.Text;
                persona.SegundoNombre = txtSegNombre.Text;
                persona.Apellidos = txtApellidos.Text;
                persona.TipoDNI = cmbDni.SelectedIndex + 1;
                persona.DNI = txtDni.Text;
                persona.Pais = (Pais)cmbPais.SelectedItem;
                persona.Departamento = (Departamento)cmbDepartamento.SelectedItem;
                persona.Distrito = txtDistrito.Text;
                persona.FechaNac = dtpFechaNac.Value.Date;

                _mntUsuario.Persona = persona;
            }
            else { return; }

            if (ValidarUsuario())
            {
                _mntUsuario.Login = txtlogin.Text;
                _mntUsuario.Passw = txtPassw.Text;
                if (_editUser)
                {
                    _mntUsuario.IdUsuarioMod = this.usuario.IdUsuario;
                    _mUsuario.Editar(_mntUsuario);
                    if (System.IO.File.Exists(@"\\JMGDIEL\Fotos\" + persona.IdPersona + ".jpg"))
                    {
                        // Use a try block to catch IOExceptions, to
                        // handle the case of the file already being
                        // opened by another process.
                        try
                        {
                            System.IO.File.Delete(@"\\JMGDIEL\Fotos\" + persona.IdPersona + ".jpg");
                        }
                        catch (System.IO.IOException e)
                        {
                            MessageBox.Show(e.Message);

                        }
                    }
                    GuardarFoto(persona.IdPersona);

                }
                else
                {
                    _mntUsuario.IdUsuarioReg = this.usuario.IdUsuario;
                    String idPersona = _mUsuario.AgregarUsuario(_mntUsuario);
                    GuardarFoto(idPersona);
                }
                DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private bool ValidarPersona()
        {
            errorProvider1.Clear();
            bool ok = true;
            if (txtPrimerNombre.Text == "")
            {
                errorProvider1.SetError(txtPrimerNombre, "Ingrese el Primer Nombre");
                ok = false;
            }
            if (txtApellidos.Text == "")
            {
                errorProvider1.SetError(txtApellidos, "Ingrese los Apellidos");
                ok = false;
            }

            if (this.foto == null)
            {
                errorProvider1.SetError(pictureBox1, "Seleccione la foto");
                ok = false;

            }
            if (ok == false) { tabControl1.SelectedIndex = 0; }
            return ok;
        }

        private bool ValidarConsumidor()
        {
            return true;
        }

        private bool ValidarUsuario()
        {
            bool ok = true;

            if (txtlogin.Text == "")
            {
                errorProvider1.SetError(txtlogin, "Ingrese el Usuario");
                ok = false;
            }

            if (txtPassw.Text.Length < 6 || txtPassw.Text.Length > 15)
            {
                lblNota.BackColor = Color.Red;
                errorProvider1.SetError(txtPassw, "Error Contraseña");
                ok = false;
            }

            if (txtRepeatPassw.Text != txtPassw.Text  && ok)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                errorProvider1.SetError(txtRepeatPassw, "Error Contraseña");
                ok = false;
            }
            return ok;
        }

        private void GuardarFoto(String nombre)
        {
            try
            {
                Image foto = ResizeImage(this.foto, 420, 500);
                foto.Save(@"\\JMGDIEL\Fotos\" + nombre + ".jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No tiene privilegios para acceder ni editar fotos");
            }
            
        }

        private void cargarDatos()
        {
            //Datos persona
            txtPrimerNombre.Text = persona.PrimerNombre;
            txtSegNombre.Text = persona.SegundoNombre;
            txtApellidos.Text = persona.Apellidos;
            cmbDni.SelectedIndex = persona.TipoDNI - 1;
            txtDni.Text = persona.DNI;
            foreach (Pais item in cmbPais.Items)
            {
                if (item.IdPais.Equals(persona.Pais.IdPais))
                {
                    cmbPais.SelectedItem = item;
                }
            }
            foreach (Departamento item in cmbDepartamento.Items)
            {
                if (item.IdDepartamento.Equals(persona.Departamento.IdDepartamento))
                {
                    cmbDepartamento.SelectedItem = item;
                }
            }
            txtDistrito.Text = persona.Distrito;
            dtpFechaNac.Value = persona.FechaNac;
            ListarContacto();
            try
            {

                using (FileStream stream = new FileStream(@"\\JMGDIEL\Fotos\" + persona.IdPersona + ".jpg", FileMode.Open, FileAccess.Read))
                {
                    foto = Image.FromStream(stream);
                }

                Image ima = ResizeImage(foto, pictureBox1.Width, pictureBox1.Height);

                pictureBox1.Image = ima;
            }
            catch (Exception ex)
            {

            }
            

            //Datos Consumidor
            foreach (Facultad facul in cmbFacultad.Items)
            {
                foreach (EAP eap in facul.escuelas)
                {
                    if (eap.IdEAP.Equals(consumidor.EAP.IdEAP))
                    {
                        cmbFacultad.SelectedItem = facul;
                        foreach (EAP escuela in cmbEscuela.Items)
                        {
                            if (escuela.IdEAP.Equals(eap.IdEAP))
                            {
                                cmbEscuela.SelectedItem = escuela;
                            }
                        }
                    }
                }
            }

            cmbCiclo.SelectedIndex = consumidor.Ciclo - 1;
            txtCodUni.Text = consumidor.CodUniversitario;
            foreach (Area item in cmbArea.Items)
            {
                if (item.IdArea.Equals(consumidor.Area.IdArea))
                {
                    cmbArea.SelectedItem = item;
                }
            }
            foreach (Grupo item in cmbGrupo.Items)
            {
                if (item.IdGrupo.Equals(consumidor.Grupo.IdGrupo))
                {
                    cmbGrupo.SelectedItem = item;
                }
            }
            ListarPeriodo();
            cargarUltimoCodigo();
            validarcodigoBD();
        }

        private void cargarDatosUsuario()
        {
            //Datos persona
            txtPrimerNombre.Text = persona.PrimerNombre;
            txtSegNombre.Text = persona.SegundoNombre;
            txtApellidos.Text = persona.Apellidos;
            cmbDni.SelectedIndex = persona.TipoDNI - 1;
            txtDni.Text = persona.DNI;
            foreach (Pais item in cmbPais.Items)
            {
                if (item.IdPais.Equals(persona.Pais.IdPais))
                {
                    cmbPais.SelectedItem = item;
                }
            }
            foreach (Departamento item in cmbDepartamento.Items)
            {
                if (item.IdDepartamento.Equals(persona.Departamento.IdDepartamento))
                {
                    cmbDepartamento.SelectedItem = item;
                }
            }
            txtDistrito.Text = persona.Distrito;
            dtpFechaNac.Value = persona.FechaNac;
            ListarContacto();
            try
            {

                using (FileStream stream = new FileStream(@"\\JMGDIEL\Fotos\" + persona.IdPersona + ".jpg", FileMode.Open, FileAccess.Read))
                {
                    foto = Image.FromStream(stream);
                }

                Image ima = ResizeImage(foto, pictureBox1.Width, pictureBox1.Height);

                pictureBox1.Image = ima;
            }
            catch (Exception ex)
            {

            }
            
            //Datos Usuario
            txtlogin.Text = _mntUsuario.Login;
            txtPassw.Text = _mntUsuario.Passw;
            txtRepeatPassw.Text = _mntUsuario.Passw;

        }

        private void cargarUltimoCodigo()
        {
            txtCodigo.Text = _mConsumidor.getUltimoCodigo(consumidor.IdConsumidor);
        }

        private void validarcodigoBD()
        {
            if (txtCodigo.Text != "")
            {
                if (txtCodigo.Text.Equals("") || txtCodigo.Text.Length != 3)
                {
                    return;
                }
                if (_mConsumidor.ValidarCodigo(((Periodo)cmbPeridos.SelectedItem).IdPeriodo, txtCodigo.Text))
                {
                    pictureCheck.Image = Comedor.Vista.Properties.Resources.accept;
                }
                else
                {
                    pictureCheck.Image = Comedor.Vista.Properties.Resources.delete;
                }
            }
        }

        #endregion

        #region eventos

        private void button1_Click(object sender, EventArgs e)
        {
            // Se crea el OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Se muestra al usuario esperando una acción
            DialogResult result = dialog.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {

                try
                {
                    Image ima1;
                    using (FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        ima1 = Image.FromStream(stream);
                        stream.Close();
                    }
                    foto = ima1;
                    Image ima = ResizeImage(foto, pictureBox1.Width, pictureBox1.Height);

                    pictureBox1.Image = ima;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Formato Incorrecto");
                }

            }
        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void cmbPais_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cargarDepartamentos();
        }

        private void cmbFacultad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEscuelas();
        }

        private void btnAddCont_Click(object sender, EventArgs e)
        {
            AgregarContacto();
        }

        private void dgvContacto_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2))
            {
                dgvContacto.Cursor = Cursors.Hand;
            }
        }

        private void dgvContacto_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2))
            {
                dgvContacto.Cursor = Cursors.Default;
            }
        }

        private void dgvContacto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2))
            {
                if (MessageBox.Show("Desea eliminar este contacto ?", "Eliminar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (editando)
                    {
                        cambioConsumidor cc = new cambioConsumidor();
                        cc.agregar = false;
                        cc.eliminar = true;
                        cc.contacto = true;
                        cc.periodo = false;
                        cc.contact = persona.contacto[e.RowIndex];
                        consumidor.cambios.Add(cc);
                    }
                    if (_userMNT && _editUser)
                    {
                        cambioUsuario cu = new cambioUsuario();
                        cu.agregar = false;
                        cu.eliminar = true;
                        cu.contact = persona.contacto[e.RowIndex];
                        _mntUsuario.cambios.Add(cu);
                    }
                    this.persona.contacto.RemoveAt(e.RowIndex);
                    ListarContacto();
                }
            }
        }

        private void btnMatr_Click(object sender, EventArgs e)
        {
            if (this.usuario.validarPrivilegio("PRI0000016"))
            {
                AgregarPeriodo();
            }
            else
            {
                MessageBox.Show("Privilegios Insuficientes");
            }
            
        }

        private void dgvPeriodos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (IsValidCellAddressPeriodo(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2))
            {
                dgvPeriodos.Cursor = Cursors.Hand;
            }
        }

        private void dgvPeriodos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddressPeriodo(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2))
            {
                dgvPeriodos.Cursor = Cursors.Default;
            }
        }

        private void dgvPeriodos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddressPeriodo(e.RowIndex, e.ColumnIndex) && (e.ColumnIndex == 2))
            {
                if (MessageBox.Show("Desea eliminar esta matricula ?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (editando)
                    {
                        cambioConsumidor cc = new cambioConsumidor();
                        cc.agregar = false;
                        cc.eliminar = true;
                        cc.contacto = false;
                        cc.periodo = true;
                        cc.cp = consumidor.periodos[e.RowIndex];
                        consumidor.cambios.Add(cc);
                    }
                    this.consumidor.periodos.RemoveAt(e.RowIndex);
                    ListarPeriodo();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConsumidor();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radioAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAuto.Checked)
            {
                txtCodigo.Enabled = false;
                btnBuscarCodigo.Enabled = false;
            }
            else
            {
                txtCodigo.Enabled = true;
                btnBuscarCodigo.Enabled = true;
            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (txtCodigo.Text.Equals("") || txtCodigo.Text.Length != 3)
                {
                    MessageBox.Show("Codigo Invalido");
                    return;
                }
                if (_mConsumidor.ValidarCodigo(((Periodo)cmbPeridos.SelectedItem).IdPeriodo, txtCodigo.Text))
                {
                    pictureCheck.Image = Comedor.Vista.Properties.Resources.accept;
                }
                else
                {
                    pictureCheck.Image = Comedor.Vista.Properties.Resources.delete;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
        }

        #endregion

       

        

        

        

       

       

       
























    }
}
