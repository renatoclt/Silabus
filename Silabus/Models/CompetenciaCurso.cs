namespace Silabus.Models
{
    public class CompetenciaCurso
    {
        private int id;
        private string descripcion;
        private int idFase;

        public CompetenciaCurso(int id, string descripcion, int idFase)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.idFase = idFase;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdFase { get => idFase; set => idFase = value; }
        public CompetenciaCurso()
        {

        }
    }
}