using ingenium.probe.library.Model;
using System;
using System.Collections.Generic;

namespace ingenium.probe.library
{
    public static class PlotDrawing
    {
        

        /// <summary>
        /// Obtiene una coordenada final de acuerdo a si es horizontal, el número de puntos y la suma de cada paso.
        /// </summary>
        /// <param name="isHorizontal">determina si la linea es horizontal</param>
        /// <param name="x">x inicial</param>
        /// <param name="y">y inicial</param>
        /// <param name="maxPoints">numero máximo de puntos</param>
        /// <param name="sumar">numero de puntos que se añadirán</param>
        /// <param name="points">interno para la recursión</param>
        /// <returns>linea vertical u horizontal</returns>
        public static Coords GetLine(bool isHorizontal, int x, int y, int maxPoints, int sumar, int points = 1) {
            var localX = x;
            var localY = y;
            var DuplicateMaxPoints = maxPoints * 2;
            if (isHorizontal)
            {
                localX = localX + sumar;
            }
            else {
                localY = localY + sumar;
            }
            if (DuplicateMaxPoints < (points + 1))
            {
                return new Coords(localX, localY);
            }
            
            return GetLine(isHorizontal, localX, localY, maxPoints, sumar, points + 1);
        }


        /// <summary>
        /// Crea un plano cartesiano
        /// </summary>
        /// <param name="x">x inicial desde arriba</param>
        /// <param name="y">y inicial desde arriba</param>
        /// <param name="maxPoints">maximo de puntos, desde el centro a los extremos</param>
        /// <param name="sumar">el numero de unidades que irá sumando cada punto</param>
        /// <returns></returns>
        public static (Coords origenX, Coords finalX, Coords origenY, Coords finalY, Coords[] x_points, Coords[] y_points) GetPlot(int x, int y, int maxPoints, int sumar)
        {
            // punto inicial, se graficará desde el punto y superior.
            var origenY = new Coords(x, y);

            // punto final de la vertical, desde arriba hacia abajo
            var finalY = GetLine(false, x, y, maxPoints, sumar);

            // punto medio del eje vertical
            var middlePoint = new Coords(x, (finalY.Y + origenY.Y)/2);

            // punto medio del eje vertical, para obtener la línea horizontal
            var yHorizonal = middlePoint.Y;

            var inicioEjeHorizontal = middlePoint.X - (maxPoints * sumar);

            // inicio ejeX
            var origenX = new Coords(inicioEjeHorizontal, yHorizonal);

            // punto de origen del punto X
            var initHorizontalX = Convert.ToInt32(origenX.X);
            var initHorizontalY = Convert.ToInt32(origenX.Y);

            // punto final del ejeX
            var finalX = GetLine(true, initHorizontalX, initHorizontalY, maxPoints, sumar);

            // coordenadas del puntoX.
            var x_coords = new List<Coords>();

            // llenado de coordenadas del punto X, partiendo desde la x del punto inicial a la x del punto final, sin contar los extremos
            for (int i = initHorizontalX + sumar; i < finalX.X; i += sumar)
            {
                // se usa el y del punto inicial.
                x_coords.Add(new Coords(i, initHorizontalY));
            }

            // x e y del punto inicial de la vertical
            var initVerticalX = Convert.ToInt32(origenY.X);
            var initVerticalY = Convert.ToInt32(origenY.Y);

            var y_coords = new List<Coords>();

            // y inicial al y final
            for (int i = initVerticalY + sumar; i < finalY.Y; i += sumar)
            {
                // usa la x del punto inicial para cada punto
                y_coords.Add(new Coords(initVerticalX, i));
            }


            return (origenX, finalX, origenY, finalY, x_coords.ToArray(), y_coords.ToArray());
        }



    }


}
