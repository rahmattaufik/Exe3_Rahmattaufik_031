using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe3_Rahmattaufik_031
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        
        public CircularList()
        {
            LAST = null;
        }
        
        public bool Search(int rollNo, ref Node previous, ref Node current)/*Searches for the specified note*/
        {
            for (previous = current = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*if the node is present at the end*/
                return true;
            else
                return (false);/*returns false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void addNode()/*Method untuk menambahkan sebuah node kedalam list*/
        {
            int rollNumber;
            string nama;
            Console.WriteLine("\namaasukkan Nomor Mahasiswa : ");
            rollNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\namaasukkan Nama Mahasiswa : ");
            nama = Console.ReadLine();
            Node nodebaru = new Node();
            nodebaru.rollNumber = rollNumber;
            nodebaru.name = nama;

            if (LAST == null || rollNumber <= LAST.rollNumber)/*Node Ditambahkan sebuah node*/
            {
                if ((LAST != null) && (rollNumber == LAST.rollNumber))
                {
                    Console.WriteLine("\nNomor Mahasiswa tidak diijinkan\n");
                    return;
                }
                nodebaru.next = LAST;
                LAST = nodebaru;
                return;
            }
            /*Menemukan lokasi Node baru didalam list*/
            Node previous, current;
            previous = LAST;
            current = LAST;

            while ((current != null) && (rollNumber >= current.rollNumber))
            {
                if (rollNumber == current.rollNumber)
                {
                    Console.WriteLine("\nNomor mahasiswa sama tidak diijinkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*Node Baru akan ditempatkan diantara previous dan current*/

            nodebaru.next = current;
            previous.next = nodebaru;

        }
        public bool delNode(int name)
        {
            Node previous, current;
            previous = current = null;
            /*Check apakah node yang dimaksud ada didalam list atau tidak*/
            if (Search(name, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == LAST)
                LAST = LAST.next;
            return true;
        }

        public void traverse()/*traverses  all the node of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.WriteLine(currentNode.rollNumber + " " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + " " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\namaenu");
                    
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Insert data in the list");
                    Console.WriteLine("5. Delete data in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true )
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                            }
                            Node prev, curr;
                            prev = curr = null;
                            Console.Write("\nEnter the roll number of the student whose record is to  be searched");
                            int num = Convert.ToInt32(Console.ReadLine());
                            if (obj.Search(num, ref prev, ref curr) == false)
                                Console.WriteLine("\nRecord not found");
                            else
                            {
                                Console.WriteLine("\nRecord Found");
                                Console.WriteLine("\nRoll Number: " + curr.rollNumber);
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            {
                                obj.addNode();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.Write("\namaasukkan rollNumber yang akan dihapus : ");
                                int rollNumber = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNumber) == false)
                                    Console.WriteLine("\nData tidak ditemukan. ");
                                else
                                    Console.WriteLine("Data dengan nomor mahasiswa " + rollNumber + " dihapus ");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
    internal class Program
    {
        
    }
}
