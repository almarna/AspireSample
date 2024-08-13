let environmentVariables = process.env;

// Iterate and log each environment variable
console.log('Listing all environment variables:');
Object.keys(environmentVariables).forEach((key) => {
    console.log(`${key}: ${environmentVariables[key]}`);
});