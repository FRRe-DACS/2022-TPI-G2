export const initialStore = {
    user: {
      id: null,
      firstName: null,
      lastName: null,
      email: null,
      tokenJwt: null,
      rol: null,
    },
    isLogged: false
  };
  
  export const types = {
    authLogin: "auth - login",
    authLogout: " auth - logout"
  };
  
  const StoreReducer = (state, action) => {
    switch (action.type) {
      case types.authLogout:
        return {
          ...state,
          user: {
            id: null,
            firstName: null,
            lastName: null,
            email: null,
            tokenJwt: null,
            rol: null,
          },
          isLogged: false,
          favs: [],
        };
      case types.authLogin:
        return {
          ...state,
          isLogged: true,
          user: action.payload,
        };
      default:
        return state;
    }
  };
  
  export default StoreReducer;
  