using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceDonkey.Models.Omdb
{
    public class MovieCollectionModel
    {
        public MovieCollectionModel(List<MovieModel> movies)
        {
            Movies = movies;
        }

        public List<MovieModel> Movies { get; }
    }
}

