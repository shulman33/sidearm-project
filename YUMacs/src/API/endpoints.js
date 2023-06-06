import axios from 'axios';

export const getSection = async (section) => {
    const endpoint = 'https://localhost:7182/api/Cms/6467d423dbfa9690dcb2ae2a/'
    const response = await axios.get(endpoint + section)
    console.log(response.data);
    return response.data;
}