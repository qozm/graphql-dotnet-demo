
```
query {
  authors{
    id
    name
  }
}
```


```
query {
  author (id: "10001"){
    id
    name
  }
  posts
    {
      id
      title
      content
    }
}
```


```
mutation {
  createAuthor(author: {id:"", name:"Hana"}) {
    id
		name
  }
}
```