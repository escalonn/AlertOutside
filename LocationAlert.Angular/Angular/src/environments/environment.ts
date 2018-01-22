// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  // libraryServiceUri: "http://ec2-34-201-125-246.compute-1.amazonaws.com/LocationAlertLibrary"
  libraryServiceUri: "http://localhost:59844"
};
