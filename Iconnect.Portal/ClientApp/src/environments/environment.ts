// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiHost: 'http://localhost:8001/',
  hostUrl: 'http://localhost:8001/',
  client_secret: '623bMugDDMafaysWv5gsgc3eM9YKH7Wm'
};


/*
*PARA O BUILD DE ELECTRON, UTILIZE O http://localhost:8001/
*PARA O BUILD DE DEBUG, UTILIZE O http://localhost:61567/
*/
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
