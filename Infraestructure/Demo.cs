using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Empleados;
using Domain.Entities;
using System.Reflection;
using static Domain.Entities.Producto;
using static Domain.Entities.Empleados.Empleado;

namespace Infraestructure
{
    public class Demo<T>
    {
       
        public T[] Ordenar(T[] generic)
        {
            if (generic.GetType().Name == "Producto")
            {
                Producto[] p=new Producto[generic.Length];
                Producto po;
                for (int i=0;i<generic.Length;i++)
                {
                     po= (Producto)Convert.ChangeType(generic[i], typeof(Producto));
                    p[i] = po;
                }
                Array.Sort(p,new ProductoOrderByPrecio());
                return (T[])Convert.ChangeType(p,typeof(T[]));
            }else if (generic.GetType().Name == "Empleado")
            {
                Empleado[] p = new Empleado[generic.Length];
                Empleado po;
                for (int i = 0; i < generic.Length; i++)
                {
                    po = (Empleado)Convert.ChangeType(generic[i], typeof(Empleado));
                    p[i] = po;
                }
                Array.Sort(p, new EmpleadoOrdenarbyCodigo());
                return (T[])Convert.ChangeType(p, typeof(T[]));
            }
            return generic;
        }
    }
}
