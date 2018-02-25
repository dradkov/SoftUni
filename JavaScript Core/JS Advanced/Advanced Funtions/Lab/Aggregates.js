function solve(args) {

    args = args.map(a=>Number(a))

   console.log('Sum = ' + args.reduce((a, b) => a+b))
   console.log('Min = ' + args.reduce((a, b) => Math.min(a,b)))
   console.log('Max = ' + args.reduce((a, b) =>Math.max(a,b)))
   console.log('Product = ' + args.reduce((a, b) =>a*b))
   console.log('Join = ' + args.join(''))
}

solve(['2','3','10','5'])