using Dominio.SalesForceApp.Repositorio;
using System;
using System.IO;

using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using Dominio.SalesForceApp.Entidade;
using System.Linq;
using Dominio.SalesForceApp.Entidade.Enums;

namespace FaixaCEP
{
    class FaixaCEP
    {

        static void Main(string[] args)
        {
            //GerarScriptCorreios();

            //GerarScriptTransportadoras();

            AtualizarRemessaExpressa();
        }
        
        static void AtualizarRemessaExpressa()
        {
            var listaRemessa = LerArquivoCorreios(true);

            foreach (var item in listaRemessa)
            {
                var repoAreaCobertura = new RepositorioAreaCobertura();
                var repoPesoValor = new RepositorioPesoValor();
                var areacoberturas = repoAreaCobertura.ListarAreas().Where(x => x.CepInicio == item.CepInicio & x.CepTermino == item.CepFim & x.TransportadoraId == 1).FirstOrDefault();

                if (areacoberturas != null)
                {

                    var pesoValor = repoPesoValor.Listar().Where(x => x.AreaCoberturaId == areacoberturas.Id & x.PesoMaximo == (Convert.ToDecimal(item.PesoAte) / 1000) & x.PesoMinimo == (Convert.ToDecimal(item.PesoDe) / 1000)).FirstOrDefault();

                    if (pesoValor != null)
                    {
                        if (item.Origem == "SAO PAULO")
                        {
                            pesoValor.Valor = item.Custo;
                        }
                        else
                        {
                            pesoValor.ValorCuritiba = item.Custo;
                        }

                        repoPesoValor.Alterar(pesoValor);
                    }
                    else
                    {
                        var pesoValorEntidate = CriarEntidadePesoValor(item, areacoberturas.Id);
                        repoPesoValor.Inserir(pesoValorEntidate);
                    }

                }
                else
                {
                    var areaCoberturaEntidade = CriarEntidadeAreaCobertura(item);
                    repoAreaCobertura.Inserir(areaCoberturaEntidade);
                    var idAreaCobertura = repoAreaCobertura.Listar().Where(x => x.CepInicio == areaCoberturaEntidade.CepInicio && x.CepTermino == areaCoberturaEntidade.CepTermino && x.TransportadoraId == 1).FirstOrDefault().Id;

                    var pesoValorEntidate = CriarEntidadePesoValor(item, idAreaCobertura);
                    repoPesoValor.Inserir(pesoValorEntidate);
                }
            }

        }

        static void GerarScriptTransportadoras()
        {

            var listaTransportadoras = LerArquivoTransportadora();

            foreach (var item in listaTransportadoras)
            {
                var repoAreaCobertura = new RepositorioAreaCobertura();
                var repoPesoValor = new RepositorioPesoValor();
                int idTransportadora = 0;
                AreaCobertura areascoberturas = new AreaCobertura();
                switch (item.NomeTransportadora)
                {
                    case "FLASH COURIER":
                        areascoberturas = repoAreaCobertura.ListarAreas().Where(x => x.CepInicio == item.CepDe & x.CepTermino == item.CepAte & x.TransportadoraId == Convert.ToInt32(Transportadoras.FlashCourier)).FirstOrDefault();
                        idTransportadora = Convert.ToInt32(Transportadoras.FlashCourier);
                        break;

                    case "INTERLOG DISTR.":
                        areascoberturas = repoAreaCobertura.ListarAreas().Where(x => x.CepInicio == item.CepDe & x.CepTermino == item.CepAte & x.TransportadoraId == Convert.ToInt32(Transportadoras.InterlogDristr)).FirstOrDefault();
                        idTransportadora = Convert.ToInt32(Transportadoras.InterlogDristr);
                        break;
                    case "TREX LOGISTICA":
                        areascoberturas = repoAreaCobertura.ListarAreas().Where(x => x.CepInicio == item.CepDe & x.CepTermino == item.CepAte & x.TransportadoraId == Convert.ToInt32(Transportadoras.TrexLogistica)).FirstOrDefault();
                        idTransportadora = Convert.ToInt32(Transportadoras.TrexLogistica);
                        break;
                    default:
                        break;
                }

                if (areascoberturas != null)
                {

                    var pesoValor = repoPesoValor.Listar().Where(x => x.AreaCoberturaId == areascoberturas.Id & x.PesoMaximo == item.ValorMax & x.PesoMinimo == item.ValorMin).FirstOrDefault();

                    if (pesoValor != null)
                    {
                        pesoValor.Valor = item.ValorCusto;
                        repoPesoValor.Alterar(pesoValor);
                    }
                    else
                    {
                        var pesoValorEntidate = CriarEntidadePesoValor(item, areascoberturas.Id);
                        repoPesoValor.Inserir(pesoValorEntidate);
                    }

                }
                else
                {
                    var areaCoberturaEntidade = CriarEntidadeAreaCobertura(item, idTransportadora);
                    repoAreaCobertura.Inserir(areaCoberturaEntidade);
                    var idAreaCobertura = repoAreaCobertura.Listar().Where(x => x.CepInicio == areaCoberturaEntidade.CepInicio && x.CepTermino == areaCoberturaEntidade.CepTermino && x.TransportadoraId == areaCoberturaEntidade.TransportadoraId).FirstOrDefault().Id;

                    var pesoValorEntidate = CriarEntidadePesoValor(item, idAreaCobertura);
                    repoPesoValor.Inserir(pesoValorEntidate);
                }
            }
        }

        static void GerarScriptCorreios()
        {
            try
            {
                var listaCorreios = LerArquivoCorreios(false);
                foreach (var item in listaCorreios)
                {
                    var repoAreaCobertura = new RepositorioAreaCobertura();
                    var repoPesoValor = new RepositorioPesoValor();
                    var areacoberturas = repoAreaCobertura.ListarAreas().Where(x => x.CepInicio == item.CepInicio & x.CepTermino == item.CepFim & x.TransportadoraId == 1).FirstOrDefault();

                    if (areacoberturas != null)
                    {

                        var pesoValor = repoPesoValor.Listar().Where(x => x.AreaCoberturaId == areacoberturas.Id & x.PesoMaximo == (Convert.ToDecimal(item.PesoAte) / 1000) & x.PesoMinimo == (Convert.ToDecimal(item.PesoDe) / 1000)).FirstOrDefault();

                        if (pesoValor != null)
                        {
                            if (item.Origem == "SAO PAULO")
                            {
                                pesoValor.Valor = item.Custo;
                            }
                            else
                            {
                                pesoValor.ValorCuritiba = item.Custo;
                            }

                            repoPesoValor.Alterar(pesoValor);
                        }
                        else
                        {
                            var pesoValorEntidate = CriarEntidadePesoValor(item, areacoberturas.Id);
                            repoPesoValor.Inserir(pesoValorEntidate);
                        }

                    }
                    else
                    {
                        var areaCoberturaEntidade = CriarEntidadeAreaCobertura(item);
                        repoAreaCobertura.Inserir(areaCoberturaEntidade);
                        var idAreaCobertura = repoAreaCobertura.Listar().Where(x => x.CepInicio == areaCoberturaEntidade.CepInicio && x.CepTermino == areaCoberturaEntidade.CepTermino && x.TransportadoraId == 1).FirstOrDefault().Id;

                        var pesoValorEntidate = CriarEntidadePesoValor(item, idAreaCobertura);
                        repoPesoValor.Inserir(pesoValorEntidate);
                    }
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        static PesoValor CriarEntidadePesoValor(Correios correio, int idAreaCobertura)
        {
            var retorno = new PesoValor();

            retorno.AreaCoberturaId = idAreaCobertura;
            retorno.PesoMinimo = (Convert.ToDecimal(correio.PesoDe) /1000);
            retorno.PesoMaximo = (Convert.ToDecimal(correio.PesoAte) / 1000);
            retorno.DataCriacao = DateTime.Now;
            retorno.UltimaAtualizacao = DateTime.Now;

            if (correio.Origem == "SAO PAULO")
                retorno.Valor = correio.Custo;
            else
                retorno.ValorCuritiba = correio.Custo;

            return retorno;
        }
        static PesoValor CriarEntidadePesoValor(Transportadora transportadora, int idAreaCobertura)
        {
            var retorno = new PesoValor();

            retorno.AreaCoberturaId = idAreaCobertura;
            retorno.PesoMinimo = transportadora.ValorMin;
            retorno.PesoMaximo = transportadora.ValorMax;
            retorno.DataCriacao = DateTime.Now;
            retorno.UltimaAtualizacao = DateTime.Now;
            retorno.Valor = transportadora.ValorCusto;

            return retorno;
        }

        static AreaCobertura CriarEntidadeAreaCobertura(Correios correio)
        {
            AreaCobertura retorno = new AreaCobertura();

            retorno.CepInicio = correio.CepInicio;
            retorno.CepTermino = correio.CepFim;
            retorno.DataCriacao = DateTime.Now.Date;
            retorno.TransportadoraId = 1;
            retorno.UltimaAtualizacao = DateTime.Now.Date;

            return retorno;
        }
        
        static AreaCobertura CriarEntidadeAreaCobertura(Transportadora transportadora, int idTransportadora)
        {
            AreaCobertura retorno = new AreaCobertura();

            retorno.CepInicio = transportadora.CepDe;
            retorno.CepTermino = transportadora.CepAte;
            retorno.DataCriacao = DateTime.Now;
            retorno.TransportadoraId = idTransportadora;
            retorno.UltimaAtualizacao = DateTime.Now;

            return retorno;

        }

        static List<Correios> LerArquivoCorreios(bool remessaExpressa)
        {
            List<Correios> listaCorreios = new List<Correios>();
            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\rgcarneiro\Downloads\CepXPeso_Correios_atualizado_Accentiv.xls;Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Correio$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        if (remessaExpressa)
                        {
                            if (dr[8].ToString() == "Remessa Expressa")
                            {
                                Correios planilhaCorreios = new Correios
                                {
                                    Origem = dr[0].ToString(),
                                    CepInicio = Convert.ToInt32(dr[1]),
                                    CepFim = Convert.ToInt32(dr[2]),
                                    PesoDe = Convert.ToInt32(dr[3]),
                                    PesoAte = Convert.ToInt32(dr[4]),
                                    Custo = Convert.ToDecimal(dr[5])
                                };

                                listaCorreios.Add(planilhaCorreios);
                            }
                        }
                        else
                        {
                            Correios planilhaCorreios = new Correios
                            {
                                Origem = dr[0].ToString(),
                                CepInicio = Convert.ToInt32(dr[1]),
                                CepFim = Convert.ToInt32(dr[2]),
                                PesoDe = Convert.ToInt32(dr[3]),
                                PesoAte = Convert.ToInt32(dr[4]),
                                Custo = Convert.ToDecimal(dr[5])
                            };

                            listaCorreios.Add(planilhaCorreios);
                        }

                        
                    }
                }
            }

            return listaCorreios;
        }

        static List<Transportadora> LerArquivoTransportadora()
        {
            List<Transportadora> listaTransportador = new List<Transportadora>();
            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\rgcarneiro\Downloads\ATRIBUIÇÃO _TRP_SGL.xls;Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [FAIXACEP$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[22].ToString() == "Normal")
                        {


                            Transportadora planilhaTransportadora = new Transportadora
                            {
                                NomeTransportadora = dr[1].ToString(),
                                CepDe = Convert.ToInt32(dr[4]),
                                CepAte = Convert.ToInt32(dr[5]),
                                ValorMin = Convert.ToInt32(dr[14]),
                                ValorMax = Convert.ToInt32(dr[15]),
                                ValorCusto = Convert.ToDecimal(dr[23])
                            };

                            listaTransportador.Add(planilhaTransportadora);

                        }
                    }
                }
            }
            return listaTransportador;
            
        }

    }
}
