namespace AppTesteDotNet.Migrations
{
    using AppTesteDotNet.Enum;
    using AppTesteDotNet.Models.Context;
    using AppTesteDotNet.Models.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppContext context)
        {
            var categoria = new Categoria()
            {
                Descricao = "Veículos e Acessórios",
                Slug = "veiculos-acessorios",
                SubCategorias = new List<SubCategoria>() {
                    new SubCategoria(){
                        Descricao ="Som",
                        Slug ="som",
                        Campos = new List<Campo>
                        {
                            new Campo{
                                Ordem =1,
                                Descricao ="Campo1",
                                Tipo = (int)HtmlCampo.CHECKBOX,
                                Lista = new List<Lista>
                                {
                                    new Lista{Descricao="Opção1"},
                                    new Lista{Descricao="Opção2" },
                                    new Lista{Descricao="Opção3"}
                                }
                            },
                            new Campo
                            {
                                Ordem=2,
                                Descricao="Campo2",
                                Tipo=(int)HtmlCampo.SELECT,
                                Lista = new List<Lista>
                                {
                                    new Lista{Descricao="Opção1"},
                                    new Lista{Descricao="Opção2" },
                                    new Lista{Descricao="Opção3"}
                                }
                            },
                            new Campo
                            {
                                Ordem=3,
                                Descricao="Campo3",
                                Tipo=(int)HtmlCampo.TEXT
                            },
                            new Campo
                            {
                                Ordem=4,
                                Descricao="Campo4",
                                Tipo=(int)HtmlCampo.TEXTAREA
                            }
                        }
                    }
                }

            };

            context.Categorias.AddOrUpdate(categoria);
            context.SaveChanges();
        }
    }
}
