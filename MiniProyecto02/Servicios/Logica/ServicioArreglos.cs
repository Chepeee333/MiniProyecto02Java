using MiniProyecto02.Modelos;

namespace MiniProyecto02.Servicios.Logica
{
    // Reto 2: redimensionamiento manual y ordenamiento de arreglos.
    public static class ServicioArreglos
    {
        public static T[] Duplicar<T>(T[] origen)
        {
            T[] nuevo = new T[origen.Length * 2];
            for (int i = 0; i < origen.Length; i++)
            {
                nuevo[i] = origen[i];
            }
            return nuevo;
        }

        public static void Agregar<T>(ref T[] arreglo, ref int cantidad, T elemento)
        {
            if (cantidad == arreglo.Length)
            {
                arreglo = Duplicar(arreglo);
            }
            arreglo[cantidad] = elemento;
            cantidad++;
        }

        public static T[] Recortar<T>(T[] origen, int cantidad)
        {
            T[] exacto = new T[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                exacto[i] = origen[i];
            }
            return exacto;
        }

        // Burbuja: mayor a menor costo total.
        public static void OrdenarPorTotalDescendente(Paquete[] paquetes)
        {
            for (int i = 0; i < paquetes.Length - 1; i++)
            {
                for (int j = 0; j < paquetes.Length - i - 1; j++)
                {
                    if (paquetes[j].Total < paquetes[j + 1].Total)
                    {
                        Paquete temporal = paquetes[j];
                        paquetes[j] = paquetes[j + 1];
                        paquetes[j + 1] = temporal;
                    }
                }
            }
        }
    }
}
