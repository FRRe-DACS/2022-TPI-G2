import { TYPES } from "../actions/carroActions";
import paquetesApi from "../paquetes.json"

export const carroInitialState = {
   paquetesApi: paquetesApi,
   carrito: [],
};

export function carroReducer(state, action) {
   switch (action.type) {
      case TYPES.ADD_TO_CART: {

      }
      case TYPES.REMOVE_ONE_FROM_CART: {

      }
      case TYPES.REMOVE_ALL_FROM_CART: {

      }
      case TYPES.CLEAR_CART: {

      }
      default:
         return state;
   }
}