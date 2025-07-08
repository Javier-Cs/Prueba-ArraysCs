
namespace ConexionSqlServ.Entity
{
    public class PersonaEntity
    {
        public int IdPersona {  get; set; }
        public string NombrePersona {  get; set; }
        public string ApellidoPersona {  get; set; }
        public int Edad {  get; set; }


        public override string ToString()
        {
            return $"ID: {IdPersona}, Nombre: {NombrePersona}, Apellido: {ApellidoPersona}, Edad: {Edad}";
        }
    }
}
