using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Generic_LinkedList
{
    public class LinkedList<T>
    {
        public Node<T> head;

        public LinkedList(Node<T> node)
        {
            head = node;
        }

        public void PrintList()
        {
            Node<T> current = head;
            if (current == null)
            {
                Console.WriteLine("No nodes in list");
            }
            else
            {
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
            }
        }
        public void Insert(T data)
        {
            Node<T> toAdd = new Node<T>
            {
                data = data
            };
            Node<T> current = head;
            while (current != null)
            {
                current = current.next;
            }
            current.next = toAdd;
        }
        public void Delete(int position)
        {
            int foundPosition = 0;
            Node<T> current = head;
            Node<T> savedNodes = new Node<T>();
            while (current != null)
            {
                if (foundPosition == position)
                {
                    savedNodes = current.next;
                    break;
                }
                current = current.next;
                foundPosition++;
            }
            current = head;
            foundPosition = 0;
            while (current != null)
            {
                if (foundPosition + 1 == position)
                {
                    current.next = savedNodes;
                    break;
                }
                current = current.next;
                foundPosition++;
            }
        }
    }
}
