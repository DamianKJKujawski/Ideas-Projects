# Repository: Other-Projects

  Simple projects implementing various random algorithms and library implementations.

## Content

  - [Introduction](#Introduction)
  - [BTree-Database](#BTree-Database)
  - [MVVM-Java](#MVVM-Java)
  - [License](#License)

## Introduction

  Projects included in the repository: 
   - BTree_Database - Database implementation based on .TXT file and B-Tree algorithm.

## BTree-Database

```
  .
  │
  ├── BTree-Database/
  │       │
  │       ├── Main.cs
  │       └── BTree_Database.cs
  │            └── BTreeNode.cs

  .
  │
  └── UnitTest/
          │
          ├── UnitTest.cs
          └── Usings.cs (NUnit.Framework)

```

Simplified Unit Test:

```
// Step 1 - Create Database:

  BTree<int> _bTree = new (3);

  _bTree.Insert(1);
  _bTree.Insert(3);
  _bTree.Insert(7);

// Step 2 - Save B-tree to file:

  _bTree.Save_ToFile("btree.db");

// Step 3 - Load B-tree from file:

  BTree<int> _loadedTree = new (3);
  _loadedTree.Load_FromFile("btree.db");

// Step 4 - Search for a value in the loaded B-tree:

  int _valueFound = _loadedTree.Search(7);
  int _valueNotFound = _loadedTree.Search(5);

// Step 5 - Check result:

  Assert.Multiple(() =>
  {
    Assert.That(_valueFound, Is.EqualTo(7));
    Assert.That(_valueNotFound, Is.EqualTo(0));
  });

```

## MVVM-Java

![image](https://github.com/DamianKJKujawski/Other-Projects/assets/160174331/6362fbcc-01eb-4e1e-8bb6-430a6c32d7c1)

## License

-



