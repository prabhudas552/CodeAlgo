using System;

class Node
{
    public int data;
    public Node next;
    public Node(int data)
    {
        this.data = data;
        next = null;
    }
}
class LinkedList
{
    Node head;
    public void AddNode(int data)
    {
        Node temp = new Node(data);
        if(head == null)
        {
            head = temp;
            return;
        }
        Node ptr  = head;
        while(ptr.next != null)
            ptr = ptr.next;
        ptr.next = temp;
    }
    public void PrintList()
    {
        Node temp = head;
        while(temp != null)
        {
            System.Console.Write(temp.data +" ");
            temp = temp.next;
        }
        System.Console.WriteLine();
    }
    public void PairWiseSwap()
    {
        if(head == null || head.next == null)
            return;
        Node prev = head;
        Node current = head.next;
        head = current;
        while(true)
        {
            Node next = current.next;
            current.next = prev;
            if(next == null || next.next == null)
            {
                prev.next = next;
                break;
            }
            prev.next = next.next;
            prev = next;
            current = prev.next;
        }
    }
}
class MainClass
{
    public static void Main(string [] args)
    {
        LinkedList list  = new LinkedList();
        list.AddNode(1);
        list.AddNode(2);
        list.AddNode(3);
        list.AddNode(4);
        list.AddNode(5);
        list.AddNode(6);
        list.AddNode(7);
        list.PrintList();
        list.PairWiseSwap();
        System.Console.WriteLine(": After Swapping :");
        list.PrintList();
    }
}