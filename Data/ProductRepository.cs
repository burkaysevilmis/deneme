using System.Collections.Generic;
using System.Linq;
using MovieApp.Models;

namespace MovieApp.Data
{
    public static class ProductRepository
    {
        private static List<Movie> _movies=null;

        static ProductRepository()
        {
            _movies=new List<Movie>(){
                new Movie(){
                    Id=1,Name="Burkay1",Description="Test1",ImageUrl="1.jpg"
                },
                   new Movie(){
                    Id=2,Name="Burkay2",Description="Test2",ImageUrl="2.jpg"
                },
                   new Movie(){
                    Id=3,Name="Burkay3",Description="Test3",ImageUrl="3.jpg"
                },
                   new Movie(){
                    Id=4,Name="Burkay4",Description="Test4",ImageUrl="4.jpg"
                },
                   new Movie(){
                    Id=5,Name="Burkay5",Description="Test5",ImageUrl="5.jpg"
                },

            };
        }
        public static List<Movie> Movies{
            get{
                return _movies;
            }
        }
        public static void AddMovie(Movie entity){
            _movies.Add(entity);
        }

        public static Movie GetById(int id){
            return _movies.FirstOrDefault(s=>s.Id==id);
        }
    }
}