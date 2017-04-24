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
    public void PrintList(Node head)
    {
        Node temp = head;
        while(temp != null)
        {
            System.Console.Write(temp.data +" ");
            temp = temp.next;
        }
        System.Console.WriteLine();
    }
    public void IsPalindrome()
    {
        Node head1 = head;
        Node head2 = head;
        head2 = ReverseList(head2);
        PrintList(head2);
        System.Console.WriteLine();
        PrintList(head);
        if(IsPalindromeUtil(head1,head2))
        {
            System.Console.WriteLine("List is Palindrome");
        }else
        {
            System.Console.WriteLine("List is not Palindrome");
        }
    }
    private bool IsPalindromeUtil(Node head1,Node head2)
    {
        bool isPalindrome = false;
        while(head1 != null && head2 != null)
        {
            if(head1.data != head2.data)
            {
                isPalindrome = false;
                return isPalindrome;
            }
            head1 = head1.next;
            head2 = head2.next;
        }
        isPalindrome = (head1 !=null || head2 != null) ? false : true;
        return isPalindrome;
    }
    private Node ReverseList(Node temp)
    {
        Node prev,current,next;
        prev = null;
        current = temp;
        while(current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        temp = prev;
        return prev;
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
        list.IsPalindrome();
    }
}