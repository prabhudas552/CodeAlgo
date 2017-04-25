using System;

class Node
{
    public int data;
    public Node next;
    public Node prev;
    public Node(int data)
    {
        this.data = data;
        next = null;
        prev = null;
    }
}
class LinkedList
{
    public Node head,clonehead;
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
    public void PrintList(Node head)
    {
        Node temp = head;
        while(temp != null)
        {
            System.Console.WriteLine(temp.data +" => "+(temp.prev != null ? temp.prev.data.ToString() :"null"));
            temp = temp.next;
        }
        System.Console.WriteLine();
    }
    public void AssignRandomPointer()
    {
        Node temp  = head;
        int data;
        while(temp != null)
        {
            Node ptr = head;
            bool isFound = false;
            System.Console.WriteLine("Enter random pointer of Node : "+temp.data);
            data = int.Parse(Console.ReadLine());
            while(ptr != null)
            {
                if(ptr.data == data)
                {
                    isFound = true;
                    break;
                }
                ptr = ptr.next;
            }
            if(!isFound)
            {
                System.Console.WriteLine("Please enter valid Node :");
                continue;
            }
            temp.prev = ptr;
            temp = temp.next;
        }
    }
    public void CloneList()
    {
        if(head == null)
            return;
        Node temp = head;
        // insert duplicate node b/w each node
        while(temp != null)
        {
            Node ptr = temp.next;
            Node newnode = new Node(temp.data);
            temp.next = newnode;
            temp.next.next = ptr;
            temp  = ptr;
        }
        // clone random pointers
        temp = head;
        while(temp != null)
        {
            temp.next.prev = temp.prev.next;
            temp = temp.next != null ? temp.next.next : temp.next;
        }
        // take out cloned list from orignal list
        clonehead = head.next;
        temp = head;
        Node temp2 = clonehead;
        while(temp != null && temp2 !=null)
        {
            temp.next = temp.next != null ? temp.next.next : temp.next;
            temp2.next = temp2.next != null ? temp2.next.next : temp2.next;
            temp = temp.next;
            temp2 = temp2.next;
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
        list.PrintList(list.head);
        list.AssignRandomPointer();
        System.Console.WriteLine(": After Assigning random pointers :");
        list.PrintList(list.head);
        System.Console.WriteLine("Cloned Linked List");
        list.CloneList();
        list.PrintList(list.clonehead);
    }
}