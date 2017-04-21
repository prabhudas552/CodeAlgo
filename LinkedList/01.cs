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
    public LinkedList(){head = null;}
    
    public void AddNode(int data)
    {
        Node temp = new Node(data);
        if(head==null)
        {
            head = temp;
            return;
        }
        Node ptr = head;
        while(ptr.next != null)
            ptr = ptr.next;
        ptr.next = temp;
    }
    public void PrintList()
    {
        if(head == null)
        return;
        Node temp = head;
        while(temp !=null )
        {
            System.Console.Write(temp.data +" ");
            temp = temp.next;
        }
    }
}
class MainClass
{
    public static void Main(String [] args)
    {
        LinkedList list = new LinkedList();
        list.AddNode(1);
        list.AddNode(2);
        list.AddNode(3);
        list.AddNode(4);
        list.AddNode(5);
        list.AddNode(6);
        list.AddNode(7);
        list.AddNode(8);
        list.PrintList();
    }
}