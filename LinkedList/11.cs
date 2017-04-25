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
        Node temp = head;
        while(temp != null)
        {
            Node newnode = new Node(temp.data);
            if(clonehead == null)
            {
                clonehead = newnode;
                temp = temp.next;
                continue;
            }
            Node ptr = clonehead;
            while(ptr.next != null)
                ptr = ptr.next;
            ptr.next = newnode;
            temp = temp.next;
        }
    }
    public void CloneRandomPointers()
    {
        Node temphead = head;
        Node tempclonehead = clonehead;
        while(temphead != null && tempclonehead != null)
        {
            Node prev = temphead.prev;
            Node ptr = clonehead;
            if(prev != null)
            {
                while(ptr != null && prev.data != ptr.data)
                {
                    ptr = ptr.next;
                }
            tempclonehead.prev = ptr;
            }
            temphead = temphead.next;
            tempclonehead = tempclonehead.next;
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
        System.Console.WriteLine("Assigning random pointers to cloned list");
        list.CloneRandomPointers();
        list.PrintList(list.clonehead);
    }
}