using GamesShop.Data.DbGamesTableAdapters;
using GamesShop.Interfaces;
using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Controllers
{
    public class UsersController : IUsersController
    {
        private readonly userTableAdapter _adapter;

        public UsersController()
        {
            _adapter = new userTableAdapter();
        }
        public bool Register(User user)
        {
            try
            {
                // Validar si el usuario o correo ya existe en la base de datos
                var existingUser = _adapter.GetDataByUsernameOrEmail(user.nombre_usuario, user.correo_electronico);
                if (existingUser.Rows.Count > 0)
                {
                    throw new Exception("El nombre de usuario o correo ya está registrado.");
                }

                // Encriptar contraseña antes de insertar
                EncryptController encryptController = new EncryptController();
                string encryptedPassword = encryptController.Encrypt(user.contrasena);

                // Insertar usuario en la base de datos
                _adapter.Insert(user.nombre_usuario, user.correo_electronico, encryptedPassword, user.fecha_creacion);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }

        public bool Login(string name, string password)
        {
            try
            {
                using (var a = new userTableAdapter())
                {

                    var b = a.GetDataByName(name).FirstOrDefault();

                    if (b != null)
                    {
                        User user = new User
                        {
                            nombre_usuario = b["nombre_usuario"].ToString(),
                            contrasena = b["contrasena"].ToString()
                        };

                        EncryptController encryptController = new EncryptController();
                        string decryptedPassword = encryptController.Decrypt(user.contrasena);


                        if (decryptedPassword == password)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }


      

    }
}


