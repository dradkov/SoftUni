function solve() {
class Post {
    constructor (title,content) {
        this.title = title
        this.content = content
    }

    toString() {
        return `Post: ${this.title}\nContent: ${this.content}\n`     
    }
}

class SocialMediaPost extends Post {
    constructor (title,content,likes,dislikes) {
        super(title,content)
        
        this.likes = likes
        this.dislikes = dislikes
        this.comments = []
    }


    addComment(comment){
        this.comments.push(comment)
    }

    toString() {

        let baseString = super.toString()+`Rating: ${this.likes - this.dislikes}`
        if (this.comments.length>0) {
            baseString+='\nComments:\n' + this.comments.map(c => ` * ${c}`).join('\n')
        }

        return baseString
    }
}

class BlogPost extends Post {
    constructor(title, content, views) {
        super(title, content);
        this.views = views;
    }

    view() {
        this.views++;
        return this
    }

    toString(){
        return super.toString()+ `Views: ${this.views}`
    }
}

 return {Post,SocialMediaPost,BlogPost}
 }



// let blog = new BlogPost('TestTitlw','Conti',0)

// console.log(blog.toString())
// console.log(blog.view())
// console.log(blog.toString())

let post = new Post("Post", "Content");

// console.log(post.toString());

// Post: Post
// Content: Content

let scm = new SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
