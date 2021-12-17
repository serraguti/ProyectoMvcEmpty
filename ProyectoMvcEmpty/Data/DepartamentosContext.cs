using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoMvcEmpty.Models;

namespace ProyectoMvcEmpty.Data
{
    public class DepartamentosContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public DepartamentosContext()
        {
            string cadenaconexion = @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2021";
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Departamento> GetDepartamentos()
        {
            string sql = "select * from dept";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Departamento> departamentos = new List<Departamento>();
            while (this.reader.Read())
            {
                Departamento dept = new Departamento();
                dept.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                dept.Nombre = this.reader["DNOMBRE"].ToString();
                dept.Localidad = this.reader["LOC"].ToString();
                departamentos.Add(dept);
            }

            this.reader.Close();
            this.cn.Close();
            return departamentos;
        }

        public Departamento FindDepartamento(int id)
        {
            string sql = "select * from dept where dept_no=@DEPTNO";
            this.com.Parameters.AddWithValue("@DEPTNO", id);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            
            this.reader.Read();
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
            departamento.Nombre = this.reader["DNOMBRE"].ToString();
            departamento.Localidad = this.reader["LOC"].ToString();

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return departamento;
        }

        public int InsertDepartamento(int id, String nombre, String localidad)
        {
            string sql = "insert into dept values (@id, @nombre, @localidad)";
            this.com.Parameters.AddWithValue("@id", id);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@localidad", localidad);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int insertados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return insertados;
        }

        public int UpdateDepartamento(int id, String nombre, String localidad)
        {
            string sql = "update dept set dnombre=@nombre, loc=@localidad "
                + " where dept_no=@id";
            this.com.Parameters.AddWithValue("@id", id);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@localidad", localidad);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int results = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return results;
        }
    }
}
