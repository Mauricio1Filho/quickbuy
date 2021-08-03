"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.environment = void 0;
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var url = "http://localhost:4050/";
exports.environment = {
    production: false,
    urlAPI: {
        usuario: url,
        produto: url,
        pedido: url
    },
    urlServerImages: "http://192.168.0.84:8080/"
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
//# sourceMappingURL=environment.js.map