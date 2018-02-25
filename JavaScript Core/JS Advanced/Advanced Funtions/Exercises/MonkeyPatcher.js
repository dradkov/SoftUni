function monkeyPatcher(cmd) {

    let commands = {
        upvote: ()=>{
           this.upvotes++
        },
        downvote: ()=>{
            this.downvotes++
        },
        score: ()=>{

            let currentUpVotes = this.upvotes
            let currentDownVotes = this.downvotes
            let totalScore = currentUpVotes-currentDownVotes
            let totalVotes = currentUpVotes+currentDownVotes

            let rating = 'new'
            let isNewPost = totalVotes<10

            if (!isNewPost) {
                updateRating()
            }

            if (totalVotes>50) {
                obfuscated()
            }

            return [currentUpVotes, currentDownVotes, totalScore, rating]

            function updateRating() {

                if (currentUpVotes > totalVotes*0.66) {
                    rating = 'hot'
                }else if (currentUpVotes>100 || currentDownVotes>100) {
                    rating = 'controversial' 
                }else if (totalScore<0 ) {
                    rating = 'unpopular'
                }    
            }

            function obfuscated() {

                let maxVotes = Math.max(currentUpVotes,currentDownVotes)
                let inflation = Math.ceil(maxVotes*0.25)
                currentUpVotes += inflation
                currentDownVotes += inflation
            }
        }
    }

    return commands[cmd]()
}








let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
monkeyPatcher.call(post, 'upvote');
monkeyPatcher.call(post, 'downvote');
let score = monkeyPatcher.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
for (let i = 0; i < 50; i++) {
    monkeyPatcher.call(post, 'downvote');
    
}
monkeyPatcher.call(post, 'downvote');        // (executed 50 times)
score = monkeyPatcher.call(post, 'score');  

 console.log(score);
