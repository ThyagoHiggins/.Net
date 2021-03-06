using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
           listaSerie[id].Exclui();
        }

        public void Insere(Serie entidade)
        {
           listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
            
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaporID(int id)
        {
            return listaSerie[id];
        }
    }
}