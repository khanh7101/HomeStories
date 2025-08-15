import React from "react";
import { Comic } from "../types/Comic";

interface Props {
  comics: Comic[];
}

const ComicList: React.FC<Props> = ({ comics }) => {
  return (
    <div>
      <h2>Danh sách truyện</h2>
      <ul>
        {comics.map((comic) => (
          <li key={comic.id}>
            <strong>{comic.title}</strong> - {comic.author}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ComicList;
