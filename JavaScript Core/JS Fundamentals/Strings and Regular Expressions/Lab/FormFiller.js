function solve(user,email,phone, application) {

    let userRegex = /<![A-Za-z]+!>/g;
    let emailRegex = /<@[A-Za-z]+@>/g;
    let phoneRegex = /<\+[A-Za-z]+\+>/g;

    let text = application.join('\n');

    text = text.replace(userRegex,user);
    text = text.replace(emailRegex,email);
    text = text.replace(phoneRegex,phone);

    
 
    console.log(text);
 
 }
 solve('Pesho',
 'pesho@softuni.bg',
 '90-60-90',
 ['Hello, <!username!>!',
  'Welcome to your Personal profile.',
  'Here you can modify your profile freely.',
  'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
  'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
  'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']
 );