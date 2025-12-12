using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichieroV2
{
    using System;
    using System.IO;

    using System;

    using System.IO;

    namespace ConsoleApp1

    {

        using System;
        using System.IO;

   
            internal class Program
            {
                private static void Main(string[] args)
                {
                    try
                    {
                        string[] extensoesValidas = { "int", "txt", "csv", "log" };

                        string PedirExtensao()
                        {
                            while (true)
                            {
                                Console.Write("Escolha o tipo de ficheiro (int, txt, csv, log): ");
                                string ext = Console.ReadLine()?.Trim().ToLower();

                                if (Array.Exists(extensoesValidas, e => e == ext))
                                    return ext;

                                Console.WriteLine("Extensão inválida! Tem de ser: int, txt, csv ou log.");
                            }
                        }

                        string mainOption;
                        do
                        {
                            Console.WriteLine("Início do Código.");
                            Console.WriteLine("1 - Criar Novo Ficheiro");
                            Console.WriteLine("2 - Ler/Modificar um Ficheiro");
                            Console.WriteLine("3 - Sair do programa");
                            Console.Write("Escolha uma opção: ");
                            mainOption = Console.ReadLine()?.Trim();

                            if (mainOption == "1")
                            {
                                Console.Write("Escolha o nome do ficheiro (sem extensão): ");
                                string fileName = Console.ReadLine()?.Trim();
                                if (string.IsNullOrWhiteSpace(fileName))
                                {
                                    Console.WriteLine("Nome inválido.");
                                    continue;
                                }

                                string ext = PedirExtensao();
                                string path = $"{fileName}.{ext}";

                                try
                                {
                                    using (var sw = new StreamWriter(path, false))
                                    {
                                    }

                                    Console.WriteLine($"Ficheiro '{path}' criado com sucesso!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Erro ao criar o ficheiro: " + ex.Message);
                                }
                            }
                            else if (mainOption == "2")
                            {
                                Console.Write("Nome do ficheiro a abrir (sem extensão): ");
                                string fileName = Console.ReadLine()?.Trim();
                                if (string.IsNullOrWhiteSpace(fileName))
                                {
                                    Console.WriteLine("Nome inválido.");
                                    continue;
                                }

                                string ext = PedirExtensao();
                                string path = $"{fileName}.{ext}";

                                if (!File.Exists(path))
                                {
                                    Console.WriteLine($"Ficheiro '{path}' não existe.");
                                    continue;
                                }
                                Console.WriteLine("");
                                Console.WriteLine("Menu de Opções");
                                Console.WriteLine("1 - Ler Ficheiro inteiro");
                                Console.WriteLine("2 - Ler Ficheiro linha a linha");
                                Console.WriteLine("3 - Escrever no ficheiro (append)");
                                Console.WriteLine("4 - Ler os primeiros 100 caracteres");
                                Console.WriteLine("5 - Sair");
                                Console.Write("Escolha uma opção: ");
                                string opcao = Console.ReadLine()?.Trim();

                                switch (opcao)
                                {
                                    case "1":
                                        using (var sr = new StreamReader(path))
                                        {
                                            string Lerfiint = sr.ReadToEnd();
                                            Console.WriteLine("Conteúdo do ficheiro:\n");
                                            Console.WriteLine(Lerfiint);
                                            Console.WriteLine("");
                                            Console.WriteLine("______________________________________");
                                        }
                                        break;

                                    case "2":
                                        using (var sr = new StreamReader(path))
                                        {
                                            Console.WriteLine("Lendo linha a linha:");
                                            string line;
                                            while ((line = sr.ReadLine()) != null)
                                            {
                                                Console.WriteLine(line);
                                                Console.WriteLine("");
                                                Console.WriteLine("______________________________________");
                                            }
                                        }
                                        break;

                                    case "3":
                                        Console.Write("Texto a adicionar (uma linha): ");
                                        string toAppend = Console.ReadLine() ?? string.Empty;
                                        using (var sw = new StreamWriter(path, true))
                                        {
                                            sw.WriteLine(toAppend);
                                            Console.WriteLine("");
                                            Console.WriteLine("______________________________________");
                                        }
                                        Console.WriteLine("Texto adicionado.");
                                        break;

                                    case "4":
                                        using (var sr = new StreamReader(path))
                                        {
                                            char[] buffer = new char[100];
                                            int read = sr.Read(buffer, 0, buffer.Length);

                                            string result = new string(buffer, 0, read);
                                            string cleaned = result.Replace("\r", "").Replace("\n", "");

                                            Console.WriteLine($"Foram lidos {cleaned.Length} caracteres:\n{cleaned}");
                                            Console.WriteLine("");
                                            Console.WriteLine("______________________________________");
                                        }
                                        break;

                                    case "5":
                                        Console.WriteLine("Sair do menu de ficheiro...");
                                        break;

                                    default:
                                        Console.WriteLine("Opção Inválida. Tente novamente.");
                                        break;
                                }
                            }
                            else if (mainOption == "3")
                            {
                                Console.WriteLine("Fim do programa...");
                            }
                            else
                            {
                                Console.WriteLine("Opção Inválida. Tente novamente.");
                            }
                        } while (mainOption != "3");
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine("Ficheiro não encontrado: " + ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Acesso não autorizado: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocorreu um erro: " + ex.Message);
                    }
                }
            }
        }
    }
