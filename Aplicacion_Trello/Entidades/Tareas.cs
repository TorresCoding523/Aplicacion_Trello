using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Trello.Entidades
{
    public class Tareas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Materia { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Asignacion { get; set; }
        public DateTime Fecha_entrega { get; set; }
        public string Estado { get; set; }
    }
}
