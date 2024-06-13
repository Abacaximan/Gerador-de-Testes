﻿using WinFormsApp.Modulo_disciplina;

namespace WinFormsApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia;
        
        public TelaMateriaForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();

            CmbDisciplina.DataSource = disciplinas;
            CmbDisciplina.DisplayMember = "Nome";
        }         

        public Materia Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;
                TxtID.Text = value.Id.ToString();
                TxtNome.Text = value.Nome;
                CmbDisciplina.SelectedItem = value.Disciplina;
                if (value.Serie == "Serie1")
                    RB1Serie.Checked = true;
                else if (value.Serie == "Serie2")
                    RB2Serie.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = TxtNome.Text;
            Disciplina disciplinaSelecionada = (Disciplina)CmbDisciplina.SelectedItem;
            string serie = RB1Serie.Checked ? "Serie1" : RB2Serie.Checked ? "Serie2" : string.Empty;

            materia = new Materia(nome, disciplinaSelecionada, serie);

            List<string> erros = materia.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
                return;
            }

            //ToDo Conversar com o Gustavo
            //if (!contexto.Materias.Contains(materia))
            //    contexto.Materias.Add(materia);

            //contexto.Gravar();
            //DialogResult = DialogResult.OK;
        }
    }
}