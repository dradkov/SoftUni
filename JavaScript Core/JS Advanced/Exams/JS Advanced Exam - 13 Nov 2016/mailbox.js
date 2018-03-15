class MailBox {
    constructor() {

        this.mails = []

    }

    get messageCount() {
        return this.mails.length
    }


    addMessage(subject, text) {

        let message = {
            subject: subject,
            text: text
        }

        this.mails.push(message)
        //this.mails({subject,text})    
        return this 
    }
    deleteAllMessages() {
        this.mails = []
    }

    findBySubject(substr) {
        return this.mails.filter(c => c.subject.includes(substr))

    }

    toString() {
        return this.mails.length != 0 ? this.mails.map(x => ` * [${x.subject}] ${x.text}`).join('\n') : ' * (empty mailbox)'
    }
}

let mb = new MailBox();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
mb.addMessage("meeting", "Let's meet at 17/11");
mb.addMessage("beer", "Wanna drink beer tomorrow?");
mb.addMessage("question", "How to solve this problem?");
mb.addMessage("Sofia next week", "I am in Sofia next week.");
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
console.log("Messages holding 'rakiya': " +
    JSON.stringify(mb.findBySubject('rakiya')));
console.log("Messages holding 'ee': " +
    JSON.stringify(mb.findBySubject('ee')));

mb.deleteAllMessages();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);

console.log("New mailbox:\n" +
    new MailBox()
    .addMessage("Subj 1", "Msg 1")
    .addMessage("Subj 2", "Msg 2")
    .addMessage("Subj 3", "Msg 3")
    .toString());