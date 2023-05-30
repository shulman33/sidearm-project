import axios from 'axios';


export const patchField = async (field, value) => {
    const endpoint = 'https://localhost:7182/api/Cms/6467d423dbfa9690dcb2ae2a/homepage_sections/'
    const response = await axios.patch(endpoint + field, value)
    console.log(response.data);
    return response.data;
}

export const getSection = async (section) => {
    const endpoint = 'https://localhost:7182/api/Cms/6467d423dbfa9690dcb2ae2a/'
    const response = await axios.get(endpoint + section)
    console.log(response.data);
    return response.data;
}

export const addSection = async (section, value) => {
    const endpoint = 'https://localhost:7182/api/Cms/6467d423dbfa9690dcb2ae2a/'
    const response = await axios.put(endpoint + section, value)
    console.log(response.data);
    return response.data;
}