import React, { useState, useRef } from 'react';
import './PhotoUpload.css';

interface PhotoUploadProps {
  onUpload: (url: string) => void;
}

const PhotoUpload: React.FC<PhotoUploadProps> = ({ onUpload }) => {
  const [preview, setPreview] = useState<string | null>(null);
  const [isDragging, setIsDragging] = useState(false);
  const fileInputRef = useRef<HTMLInputElement>(null);

  const handleFileChange = (file: File) => {
    const reader = new FileReader();
    reader.onloadend = () => {
      const result = reader.result as string;
      setPreview(result);
      onUpload(result);
    };
    reader.readAsDataURL(file);
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      handleFileChange(file);
    }
  };

  const handleDragOver = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    setIsDragging(true);
  };

  const handleDragLeave = () => {
    setIsDragging(false);
  };

  const handleDrop = (e: React.DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    setIsDragging(false);
    
    const file = e.dataTransfer.files?.[0];
    if (file && file.type.startsWith('image/')) {
      handleFileChange(file);
    }
  };

  const triggerFileInput = () => {
    if (fileInputRef.current) {
      fileInputRef.current.click();
    }
  };

  const removeImage = () => {
    setPreview(null);
    if (fileInputRef.current) {
      fileInputRef.current.value = '';
    }
  };

  return (
    <div 
      className={`photo-upload ${isDragging ? 'dragging' : ''}`}
      onDragOver={handleDragOver}
      onDragLeave={handleDragLeave}
      onDrop={handleDrop}
      onClick={triggerFileInput}
    >
      <input 
        type="file" 
        accept="image/*"
        onChange={handleInputChange}
        ref={fileInputRef}
        style={{ display: 'none' }}
      />
      
      {!preview ? (
        <div className="upload-content">
          <div className="upload-icon">📁</div>
          <div className="upload-text">
            <strong>Click to upload</strong> or drag and drop
          </div>
          <div className="upload-hint">
            PNG, JPG, GIF up to 5MB
          </div>
        </div>
      ) : (
        <div className="preview-container">
          <img 
            src={preview} 
            alt="Preview" 
            className="preview-image" 
          />
          <button 
            type="button" 
            className="remove-button"
            onClick={(e) => {
              e.stopPropagation();
              removeImage();
            }}
          >
            Remove Image
          </button>
        </div>
      )}
    </div>
  );
};

export default PhotoUpload;