
```
query {
  authors{
    id
    firstName
    lastName
  }
}
```


```
query {
  author (id: 1){
    id
    firstName
    lastName
  }
  posts
    {
      id
      title
      content
    }
}
```