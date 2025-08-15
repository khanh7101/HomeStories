import apiClient from "./apiClient";
import { Comic } from "../types/Comic";

export const comicApi = {
  getAll: async (): Promise<Comic[]> => {
    const res = await apiClient.get<Comic[]>("/comics");
    return res.data;
  }
};
