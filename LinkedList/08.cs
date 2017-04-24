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
        Node temp = head;
        while(temp != null && temp.next != null)
        {
            int tempdata = temp.next.data;
            temp.next.data = temp.data;
            temp.data = tempdata;
            temp = temp.next.next;
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
        list.AddNode(3);
        list.AddNode(2);
        list.AddNode(1);
        list.PrintList();
        list.PairWiseSwap();
        System.Console.WriteLine(": After Swapping :");
        list.PrintList();
    }
}