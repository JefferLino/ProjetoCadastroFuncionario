//-----------------------------------------------------------------------
// <copyright file="CriptografiaDeValores.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace JL.Infra.Utilitarios.Cripotografia
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Classe responsável por cripootgrafar de valores informados.
    /// </summary>
    public static class CriptografiaDeValores
    {
        /// <summary>
        /// Calcula MD5 Hash de uma determinada string passada como parametro.
        /// </summary>
        /// <param name="valor">String contendo o valor que deverá ser criptografada para MD5 Hash.</param>
        /// <returns>string com 32 caracteres com a senha criptografada.</returns>
        public static string CalculaHash(string valor)
        {
            try
            {
                MD5 md5 = MD5.Create();

                byte[] inputBytes = Encoding.ASCII.GetBytes(valor);
                byte[] hash = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                return sb.ToString(); // Retorna senha criptografada.
            }
            catch (Exception)
            {
                return null; // Caso encontre erro retorna nulo
            }
        }
    }
}
