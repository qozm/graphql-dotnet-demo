
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


```
# ≤‚ ‘Œ¥Õ®π˝£¨‘›¥Ê
mutation {
  createPost(post: { title:"Groovy-2", content:"This is a series of articles on Groovy-2."}) {
    id
		title
		content
  }
}
```