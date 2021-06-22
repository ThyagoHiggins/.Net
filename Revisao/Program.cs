using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceALuno = 0;
            string opcao = OpcaoUsuario();


            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do Aluno: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)) 
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        alunos[indiceALuno] = aluno;
                        indiceALuno++;

                        break;

                    case "2":

                        foreach (var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                 Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota} ");
                            }
                           
                        }


                        break;

                    case "3":
                        decimal notaTOtal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i> alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTOtal = notaTOtal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTOtal / nrAlunos;
                        Conceito final;
                        if(mediaGeral < 2)
                        {
                            final = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            final = Conceito.D;
                            
                        }
                        else if (mediaGeral < 6)
                        {
                            final = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            final = Conceito.B;
                        }
                        else 
                        {
                            final = Conceito.A;
                        }
                        Console.WriteLine($"A média geral dos alunos é {mediaGeral} e o conceito é {final}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = OpcaoUsuario();

            }

        }

        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informew a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            String opcao = Console.ReadLine();
            return opcao;
        }
    }
}
