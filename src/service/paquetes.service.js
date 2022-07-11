import axios from "axios";

const baseUrl = "https://localhost:7190/api"

export const getPaquetes = async () => {
    const endpoint = `${baseUrl}/Package/GetPackagesWithServices`;
    return await axios.get(endpoint)
       .then(response => response.data)
 }