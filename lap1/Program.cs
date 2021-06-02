using System;
using lap1.controller;
using lap1.entity;
using lap1.model;
using lap1.service;
using lap1.view;

namespace lap1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.GetMenu();
        }
    }
}