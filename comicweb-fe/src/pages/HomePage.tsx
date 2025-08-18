import React, { useEffect, useState } from "react";
import { comicApi } from "../api/comicApi";
import type { Comic } from "../types/Comic";
import ComicList from "../components/ComicList";

const HomePage: React.FC = () => {
  const [comics, setComics] = useState<Comic[]>([]);

  useEffect(() => {
    comicApi.getAll()
      .then((data) => setComics(data))
      .catch((err) => console.error(err));
  }, []);

  return (
    <div>
      <h1>Trang chủ</h1>
      <ComicList comics={comics} />
    </div>
  );
};

export default HomePage;
