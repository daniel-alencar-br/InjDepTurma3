using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjDep
{
    // Nivel 1 - UMA GRANDE CLASSE 
    // Nivel 2 - Varias classes dependendo umas das outras
    //           Alto Acoplamento
    // Nivel 3 - Injeção de Dependencia / Baixo Acoplamento
    
    public interface IBanco
    {
        void Conectar();
        void EnviarPix();
    }

    public class Bradesco : IBanco
    {
        public void Conectar()
        {
            //
            // Comp segurança
            //
        }
        public void EnviarPix()
        {
            //
        }
    }

    public class Santander : IBanco
    {
        public void Conectar()
        {
            //
            // Token certificado digital fisico
            //
        }
        public void EnviarPix()
        {
            //
        }
    }

    public class Pagamentos
    {
        IBanco MeuBanco;

        // Constructor Dependency Injection
        public Pagamentos(IBanco A)
        {
            MeuBanco = A;
        }

        public void RealizarTransferencia()
        {
            MeuBanco.Conectar();
            MeuBanco.EnviarPix();
        }

        // Method Injection Dependency
        public void PagarConta(IBanco Algo)
        {
            Algo.Conectar();
        }
    }
    
   

    public class Sistema
    {
        public void ModuloFinanceiro()
        {
            Bradesco MeuBanco = new Bradesco();
            Santander BancoPJ = new Santander();

            Pagamentos ContaPessoal = new Pagamentos(MeuBanco);
            ContaPessoal.RealizarTransferencia();

            Pagamentos ContaEmpresa = new Pagamentos(BancoPJ);
            ContaEmpresa.RealizarTransferencia();

            ContaEmpresa.PagarConta(BancoPJ);
        }
    }
    }


